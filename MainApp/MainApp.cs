using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using array_mlx;
using twoMlxSensors;
using oneMlxSensor;
using BaseSensor;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using System.Globalization;
using System.IO;
using Serilog;



namespace MainApp
{
    public partial class MainApp : Form
    {
        // Timer for experiment.
        private Timer _expTimer = new Timer()
        {
            Interval = 1000
        };

        // Timer for calibration.
        private Timer _calTimer = new Timer()
        {
            Interval = 1000
        };

        private bool _expGoing = false;

        private double _globaltime = 0;

        private string _tempSavePath = AppDomain.CurrentDomain.BaseDirectory;

        private StreamWriter _tempWriter = null;

        private bool _isTempRecording = false;

        private CultureInfo _culInfo = CultureInfo.InvariantCulture;

        private int _secondsTillEnd = 0;

        //Forms
        private ArraySensor array = new ArraySensor();
        private OneMLXForm oneMlxSensor = new OneMLXForm();
        private TwoMLXForm twoMlxSensors = new TwoMLXForm();
        private Calibration calibration = new Calibration();
        private PID pidForm = new PID();


        // Plots.
        private PlotModel _objTempPlotModel = new PlotModel()
        {
            Title = "Object Temperature",
            PlotAreaBackground = OxyColors.Black,
            DefaultColors = new List<OxyColor>
            {
                OxyColors.Red,
                OxyColors.Green,
                OxyColors.Blue
            },
            TitleFontSize = 10,
            TitleFontWeight = 400,
            LegendFontWeight = 500,
            LegendFontSize = 16,
            LegendTextColor = OxyColors.White
        };

        private PlotModel _ambTempPlotModel = new PlotModel()
        {
            Title = "Ambient Temperature",
            PlotAreaBackground = OxyColors.Black,
            DefaultColors = new List<OxyColor>
            {
                OxyColors.Red,
                OxyColors.Green,
                OxyColors.Blue
            },
            TitleFontSize = 10,
            TitleFontWeight = 400,
            LegendFontWeight = 500,
            LegendFontSize = 16,
            LegendTextColor = OxyColors.White
        };

        // plot for Agilent current
        PlotModel _agPlotModel = new PlotModel()
        {
            Title = "Laser current",
            PlotAreaBackground = OxyColors.Black,
            DefaultColors = new List<OxyColor>
            {
                OxyColors.Green,
                OxyColors.Blue
            },
            TitleFontSize = 10,
            TitleFontWeight = 400,
            LegendFontWeight = 500,
            LegendFontSize = 16,
            LegendTextColor = OxyColors.White
        };
        private void SetGraphData(PlotView pw, double x, double[] ys, bool isLaserGraph)
        {
            var xAxis = pw.Model.Axes[0];
            var yAxis = pw.Model.Axes[1];

            double minY = ys.Min();
            double maxY = ys.Max();

            // Scale X axis.
            if (x > xAxis.Maximum - 30)
            {
                xAxis.Maximum += 50;
                xAxis.Minimum += 50;
            }

            // Scale Y axis.
            if (isLaserGraph)
            {
                if (yAxis.Maximum - 0.1 < maxY)
                    yAxis.Maximum += 0.1;
                if (yAxis.Maximum - 0.3 > maxY)
                    yAxis.Maximum -= 0.1;
                if (yAxis.Minimum + 0.1 > minY)
                    yAxis.Minimum -= 0.1;
                if (yAxis.Minimum + 0.3 < minY)
                    yAxis.Minimum += 0.1;
            }
            else
            {
                if (yAxis.Maximum - 1 < maxY)
                    yAxis.Maximum += 1;
                if (yAxis.Maximum - 3 > maxY)
                    yAxis.Maximum -= 1;
                if (yAxis.Minimum + 1 > minY)
                    yAxis.Minimum -= 1;
                if (yAxis.Minimum + 3 < minY)
                    yAxis.Minimum += 1;
            }

            // Set data.
            for (int i = 0; i < ys.Length; i++)
            {
                (pw.Model.Series[i] as LineSeries).Points.Add(new DataPoint(x, ys[i]));
            }
            pw.InvalidatePlot(false);
        }
        // Helper logging methods
        private void AddInfo(string txt)
        {
            AppendText(rtbInfo, txt + "\n", Color.Black);
        }

        private void AddError(string txt)
        {
            AppendText(rtbInfo, txt + "\n", Color.Red);
        }

        private void AppendText(RichTextBox box, string txt, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(txt);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }
        public MainApp()
        {
            InitializeComponent();

            // To log information.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logfile.json", shared: true)
                .CreateLogger();

            _expTimer.Tick += new EventHandler(this.experimentTimer_Tick);
            _calTimer.Tick += new EventHandler(this.calibrationTimer_Tick);

            tbTempFilePath.Text = _tempSavePath;
            txtTempFileName.Text = "Record_" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss") + ".txt";

            // object temperature plot
            _objTempPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 120,
                IsAxisVisible = false
            });
            _objTempPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 17,
                Maximum = 23
            });
            //series for sensor temperature
            _objTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Sensor",
                TextColor = OxyColors.Red
            });
            //series for calibrated temperature
            _objTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Calibrated",
                TextColor = OxyColors.Green,
                IsVisible = true
            });
            // series for target temperature in PID controller
            _objTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Target",
                TextColor = OxyColors.Blue,
                IsVisible = true
            });
            this.pltObjTemp.Model = _objTempPlotModel;

             //Ambient Temperature plot
            _ambTempPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 120,
                IsAxisVisible = false
            });
            _ambTempPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 17,
                Maximum = 23
            });

            //series for sensor temperature
            _ambTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Sensor",
                TextColor = OxyColors.Red
            });
            //series for calibrated temperature
            _ambTempPlotModel.Series.Add(new LineSeries()
            {
                Title = "Calibrated",
                TextColor = OxyColors.Green,
                IsVisible = true
            });
            this.pltAmbTemp.Model = _ambTempPlotModel;

            // laser current plot
            _agPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 120,
                IsAxisVisible = false
            });
            _agPlotModel.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                Minimum = 0.5,
                Maximum = 1.5
            });
            //series for laser current
            _agPlotModel.Series.Add(new LineSeries()
            {
                Title = "Current",
                TextColor = OxyColors.Green
            });
            this.pltLaserCurrent.Model = _agPlotModel;

           
        }
        private void BtnSelectSensor_Click(object sender, EventArgs e)
        {
          if (cmbSensors.SelectedIndex == 0)
            {
                Log.Information("MLX90621 Infrared (IR) sensor array selected.");
                array = new ArraySensor();
                array.Show();
                btnSelectSensor.Enabled = false;
            }
          else if (cmbSensors.SelectedIndex == 1)
            {
                Log.Information("MLX90614 Infrared Thermometer selected.");
                oneMlxSensor = new OneMLXForm();
                oneMlxSensor.Show();
                btnSelectSensor.Enabled = false;
            }
          else if (cmbSensors.SelectedIndex == 2)
            {
                Log.Information("Two MLX90614 Infrared Thermometers selected.");
                twoMlxSensors = new TwoMLXForm();
                twoMlxSensors.Show();
                btnSelectSensor.Enabled = false;
            }
          else
            {
                AddError("No sensor selected.");
            }         
        }

        private void BtnCancelSelection_Click(object sender, EventArgs e)
        {
            btnSelectSensor.Enabled = true;
            cmbSensors.SelectedIndex = -1;

            // Closes the sensor interface.
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name != "MainApp" && Application.OpenForms[index].Name != "Calibration")
                {
                    Application.OpenForms[index].Close();
                }
            }
        }

        private void BStartExperiment_Click(object sender, EventArgs e)
        {          
            if (!_expGoing)
            {
                Log.Information("Experiment started.");
                if (btnSelectSensor.Enabled == false) // To see if sensor has been selected.
                {
                    // To see if send button is enabled.
                    if (array.AvgTemperature != null || oneMlxSensor.ObjectTemperature != null || twoMlxSensors.AvgObjTemperature != null)  
                    {
                        _expGoing = true;
                        btnStartExperiment.Text = "Stop Experiment";
                        txtExperimentStarted.Text = "Experiment Going";
                        txtExperimentStarted.BackColor = Color.Green;
                        _expTimer.Start();
                        _secondsTillEnd = (int)(nudExpTime.Value * 60);
                        txtExpTime.Visible = true;
                        nudExpTime.Visible = false;
                        txtExpTime.Text = TimeSpan.FromSeconds(_secondsTillEnd).ToString();
                        if (cbSaveData.Checked)
                        {
                            _isTempRecording = true;
                            string fileName = txtTempFileName.Text;
                            if (string.IsNullOrWhiteSpace(fileName) || fileName.StartsWith("Record_"))
                            {
                                fileName = "Record_" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss") + ".txt";
                            }
                            if (!fileName.ToUpper().EndsWith(".TXT"))
                                fileName = fileName + ".txt";
                            txtTempFileName.Text = fileName;
                            string filePath = Path.Combine(tbTempFilePath.Text, fileName);
                            _tempWriter = new StreamWriter(filePath);
                            _tempWriter.WriteLine("Time (s)\tObject temperature\tAmbient Temperature\tCalibrated ambient temperature" +
                             "\tCalibrated object temperature");
                        }
                    }
                    else
                    {
                        AddError("No data received. Please, verify that sending is enabled on the sensor's interface.");
                    }
                }
                else
                {
                    AddError("No sensor selected.");
                }
            }
            else
            {
                Log.Information("Experiment has ended.");
                _expGoing = false;
                btnStartExperiment.Text = "Start Experiment";
                txtExperimentStarted.Text = "Experiment Not Going";
                txtExperimentStarted.BackColor = Color.Red;
                _expTimer.Stop();
                array.AvgTemperature = null;
                oneMlxSensor.ObjectTemperature = null;
                twoMlxSensors.AvgObjTemperature = null;
                txtExpTime.Visible = false;
                nudExpTime.Visible = true;
                if (_isTempRecording)
                {
                    _tempWriter.Flush();
                    _tempWriter.Close();
                    _isTempRecording = false;
                }
            }
        }

        private void experimentTimer_Tick(object sender, EventArgs e)
        {
            if (_secondsTillEnd <= 0)
            {

                _expGoing = false;
                btnStartExperiment.Text = "Start Experiment";
                txtExperimentStarted.Text = "Experiment Not Going";
                txtExperimentStarted.BackColor = Color.Green;
                txtExpTime.Visible = false;
                nudExpTime.Visible = true;
                _expTimer.Stop();
                if (_isTempRecording)
                {
                    _tempWriter.Flush();
                    _tempWriter.Close();
                    _isTempRecording = false;
                }
            }
            else
            {
                _globaltime += 1;
                if (cmbSensors.SelectedIndex == 0)
                {
                    try
                    {                      
                        double objTemp = Convert.ToDouble(array.AvgTemperature);
                        Calibration calibration = new Calibration();
                        SetGraphData(pltObjTemp, _globaltime, new double[] { objTemp }, false);
                        if (_isTempRecording)
                        {
                            _tempWriter.WriteLine(_globaltime.ToString(_culInfo) + "\t" + "\t" + objTemp.ToString(_culInfo));
                        }
                    }
                    catch (FormatException ex) { Log.Error(ex, "Error"); }
                }
                else if (cmbSensors.SelectedIndex == 1)
                {
                    try
                    {
                        double objTemp = Convert.ToDouble(oneMlxSensor.ObjectTemperature, CultureInfo.InvariantCulture);
                        double ambTemp = Convert.ToDouble(oneMlxSensor.AmbientTemperature, CultureInfo.InvariantCulture);
                        SetGraphData(pltObjTemp, _globaltime, new double[] { objTemp }, false);
                        SetGraphData(pltAmbTemp, _globaltime, new double[] { ambTemp }, false);
                        if (_isTempRecording)
                        {
                            _tempWriter.WriteLine(_globaltime.ToString(_culInfo) + "\t" + "\t" + objTemp.ToString(_culInfo));
                        }
                    }
                    catch (FormatException ex) { Log.Error(ex, "Error"); }
                }
                else if (cmbSensors.SelectedIndex == 2)
                {
                    try
                    {
                        double objTemp = Convert.ToDouble(twoMlxSensors.AvgObjTemperature, CultureInfo.InvariantCulture);
                        double ambTemp = Convert.ToDouble(twoMlxSensors.AvgAmbTemperature, CultureInfo.InvariantCulture);
                        SetGraphData(pltObjTemp, _globaltime, new double[] { objTemp }, false);
                        SetGraphData(pltAmbTemp, _globaltime, new double[] { ambTemp }, false);
                        if (_isTempRecording)
                        {
                            _tempWriter.WriteLine(_globaltime.ToString(_culInfo) + "\t" + "\t" + objTemp.ToString(_culInfo));
                        }
                    }
                    catch (FormatException ex) { Log.Error(ex, "Error"); }
                }
                txtExpTime.Text = TimeSpan.FromSeconds(_secondsTillEnd).ToString();
                _secondsTillEnd -= 1;
            }                                   
        }

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            array.Dispose();
            oneMlxSensor.Dispose();
            twoMlxSensors.Dispose();
            calibration.Dispose();
            pidForm.Dispose();
            Log.CloseAndFlush();
        }

        // User can select path where to save experiment data.
        private void BtnSelectTempPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    _tempSavePath = fbd.SelectedPath;
                    tbTempFilePath.Text = fbd.SelectedPath;
                }
            }
        }
        private void BtnCalibration_Click(object sender, EventArgs e)
        {
      
            if (btnSelectSensor.Enabled == false)
            {             
                btnCalibration.Enabled = false;
                Log.Information("Calibration has started.");
                calibration = new Calibration();
                _calTimer.Start();
                calibration._evtForm += new ShowFrm(CalibrationHelper);  // Method for enabling Calibration button from it's form.            
                calibration.Show();
            }
            else
                AddError("No Sensor Selected.");           
        }

        // Calibration timer needed for sending varying temperature value to the calibration form each second.
        private void calibrationTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                calibration._objTemp = Convert.ToDouble(array.AvgTemperature);
            }
            catch { calibration._objTemp = 0; }
            
        }

        // To enable button from calibration form and stopping the timer.
        private void CalibrationHelper()
        {
            btnCalibration.Enabled = true;
            _calTimer.Stop();
            textBox4.Text = calibration._sensorCalA.ToString();
            textBox3.Text = calibration._sensorCalB.ToString();
        }

        private void BtnPIDControl_Click(object sender, EventArgs e)
        {
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "PID")
                {
                    Application.OpenForms[index].Close();
                }
            }
            pidForm = new PID();
            pidForm.Show();
        }
    }
}
