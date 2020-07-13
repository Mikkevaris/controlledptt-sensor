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
using oneMlxSensor;
using twoMlxSensors;
using System.Globalization;
using Serilog;

namespace MainApp
{
    public delegate void ShowFrm();
    public partial class Calibration : Form
    {
        public event ShowFrm _evtForm;

        // Timer for calibration.
        private Timer _calTimer = new Timer()
        {
            Interval = 1000
        };

        public double _objTemp { get; set; }

        private double _calObjTemp = 0;

        private double _ambTemp = 0;

        private double _calAmbTemp = 0;

        // Public variables for sending to MainApp form.
        public double _sensorCalA { get; set; }

        public double _sensorCalB { get; set; }

        private CultureInfo _culInfo = CultureInfo.InvariantCulture;

        //Sensor forms
        private ArraySensor arraySensor = new ArraySensor();
        private OneMLXForm oneMlxSensor = new OneMLXForm();
        private TwoMLXForm twoMlxSensors = new TwoMLXForm();

        public Calibration()
        {
            InitializeComponent();
            _calTimer.Tick += new EventHandler(this.CalibrationTimer_Tick);
          
            // To log information.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("C:/Users/mikke/controlledptt-sensor/MainApp/bin/Debug/logfile.json", shared: true)
                .CreateLogger();

        }

        private void NudSensorCalA_ValueChanged(object sender, EventArgs e)
        {
            _sensorCalA = (double)nudSensorCalA.Value;
        }

        private void NudSensorCalB_ValueChanged(object sender, EventArgs e)
        {
            _sensorCalB = (double)nudSensorCalB.Value;
        }

        private double GetCalibratedObjectTemp(double objTemp)
        {
            if (cbNoObjCalibration.Checked)
                return objTemp;

            return _sensorCalA * objTemp + _sensorCalB;
        }

        private double GetCalibratedAmbientTemp(double ambTemp)
        {
            if (cbNoAmbCalibration.Checked)
                return ambTemp;

            return (double)nudRealAmbTemp.Value;
        }

        private void CalibrationTimer_Tick(object sender, EventArgs e)
        {       
            rtbObjTemp.Text = _objTemp.ToString();
            rtbCalObjTemp.Text = GetCalibratedObjectTemp(_objTemp).ToString();
            
            // Sets the measured temperature from sensor to DataGrid's selected row's first index. 
            if (dgCalibration.CurrentCell != null)
            {
                string address = dgCalibration.CurrentCellAddress.Y.ToString();     //To see which row is selected.
                dgCalibration.Rows[Convert.ToInt32(address)].Cells[0].Value = _objTemp.ToString();
            }
            

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Log.Information("Calibration cancelled.");
            _calTimer.Stop();
            this.Hide();
            _evtForm();        
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Log.Information("Calibration done.");
            _calTimer.Stop();
            this.Close();
            _evtForm();
        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            _calTimer.Start();
        }

        private void Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            _calTimer.Stop();
            _evtForm();
        }

        // Value in cell cannot be changed when value has been set.
        private void DgCalibration_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgCalibration.CurrentCell.Value != null)
            {
                dgCalibration.CurrentCell.ReadOnly = true;
            }
        }
    }
}
