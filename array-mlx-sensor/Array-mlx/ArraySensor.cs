using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using BaseSensor;
using System.Globalization;
using Serilog;


namespace array_mlx
{
    public partial class ArraySensor : BaseSensorForm
    {
        
        // COM port connection vars.
        private SerialPort _comPort = null; // COM port connection.

        private string _received = string.Empty; // String to keep received data.

        private bool _comConnected = false; // Variable indicating if connection is open.

        private bool _sendGoing = false;

        private Timer _sendTimer = new Timer()
        {
            Interval = 1000
        };

        // Variables for calculating average temperature of chosen cells.
        private int _howManyCellsChosen = 0; 

        private double _totalTemperatureOfCells = 0;


        public ArraySensor()
        {
            InitializeComponent();
            cbBaudRate.SelectedIndex = 6;
            _sendTimer.Tick += new EventHandler(this.sendDataTimer_Tick);
            btnSendRedBoard.Enabled = false;

            // To log information.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C:/Users/mikke/controlledptt-sensor/MainApp/bin/Debug/logfile.json", shared: true)
                .CreateLogger();

        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {


            while (_comPort.BytesToRead > 0) // Reads all available serial input.
                                             // Without this there will be a lag displaying the data.
            {
                try

                {
                    _received = _comPort.ReadLine(); // One line must contain all the temperatures measured in Celcius.

                    this.Invoke(new EventHandler(DisplayData)); // Display received temperatures.
                }
                catch
                {
                }
            }

        }

        private void DisplayData(object sender, EventArgs e)
        {

            txtAllReceivedData.AppendText(_received);
            txtAllReceivedData.ScrollToCaret();

            // Data visualisation.
            VisualizeData();
        }

        private void BtnGetComPorts_Click(object sender, EventArgs e)
        {
            cbPorts.Items.Clear();
            var comPortNames = SerialPort.GetPortNames();
            if (comPortNames.Length > 0)
            {
                cbPorts.Items.AddRange(comPortNames);
                cbPorts.SelectedIndex = 0;
            }
        }

        private void BtnConnRedBoard_Click(object sender, EventArgs e)
        {
            if (!_comConnected)
            {

                var portName = cbPorts.SelectedItem.ToString();

                try
                {
                    _comPort = new SerialPort(portName, Convert.ToInt32(cbBaudRate.SelectedItem));
                    _comPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                    _comPort.Open();
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message,
                        "Something went wrong. Check no other app is connected to " + portName + ".",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Log.Error(ex.Message);
                }

                btnConnRedBoard.Text = "Disconnect";
                txtConnectedStatus.Text = "Connected";
                txtConnectedStatus.BackColor = Color.Green;
                _comConnected = true;
                btnSendRedBoard.Enabled = true;
                Log.Information("Connected to Board.");

            }
            else
            {
                if (!_comPort.IsOpen)
                {
                    throw new ArgumentException("The Com Port is not open!");
                }
                _comPort.Close();
                _comPort = null;
                btnConnRedBoard.Text = "Connect";
                txtConnectedStatus.Text = "Not Connected";
                txtConnectedStatus.BackColor = Color.Red;
                btnSendRedBoard.Enabled = false;
                _comConnected = false;
                Log.Information("Disconnected from Board.");

            }
        }
        private void BtnClearData_Click(object sender, EventArgs e)
        {
            txtAllReceivedData.Clear();
            txtCalculate.Clear();
            ResetCells(this, "", Color.White, typeof(Button));
            _totalTemperatureOfCells = 0;
            _howManyCellsChosen = 0;
            txtCalculate.Text = "0.00";
        }

        // Method that resets Cells in Temperature Visualization.
        private void ResetCells(Control parent, string btnText, Color backColor, Type controlType)
        {
            if (parent.GetType() == controlType && parent != btnClearData &&
                parent != btnConnRedBoard && parent != btnGetComPorts &&
                parent != btnSendRedBoard && parent != btnBaudRate &&
                parent != btnSelectAll)
            {
                parent.Text = btnText;
                parent.BackColor = backColor;
                parent.Enabled = true;
                parent.ForeColor = Color.Black;
            }

            // Look through each control to see if it contains any buttons.
            foreach (Control child in parent.Controls)
            {  
                ResetCells(child, btnText, backColor, controlType);
            }
        }
        // Method to see which cells are selected for temperature calculations.
        private void CellsChosen(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Enabled = false;   // Cell can not be selected more than once.
            _howManyCellsChosen++;
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            _howManyCellsChosen = 64;
            foreach (Control button in panel1.Controls)
            {
                button.Enabled = false;
            }           
        }

        // When TextChanged event of button is raised it invokes this method.
        private void CalculateAvg(object sender, EventArgs e)
        {
            _totalTemperatureOfCells = 0;

            // Look through all the Cells that was chosen and add their temperatures. 
            foreach (Control button in panel1.Controls)
            {
                if (button.Enabled == false)
                {
                    double.TryParse(button.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double temperature);
                    _totalTemperatureOfCells += temperature;
                }
            }

            if (_howManyCellsChosen != 0)
            {
                txtCalculate.Text = (_totalTemperatureOfCells / _howManyCellsChosen).ToString("F");    // Print the average with two decimals.
            }
        }

        // Two methods to visualize which cells has been chosen:

        // To see whenever cell gets disabled.
        private void Cell_EnableChanged(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.ForeColor = Color.White;
        }

        // Turns disabled cell's text to white.
        private void Cell_Paint(object sender, PaintEventArgs e)
        {
            dynamic button = sender as Button;
            dynamic drawBrush = new SolidBrush(button.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(button.Text, button.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void VisualizeData()
        {
            var temperatures = _received.Split('\t');

            // Set the temperature values to cells.
            btn1.Text = temperatures[0]; btn2.Text = temperatures[1]; btn3.Text = temperatures[2]; btn4.Text = temperatures[3];
            btn5.Text = temperatures[4]; btn6.Text = temperatures[5]; btn7.Text = temperatures[6]; btn8.Text = temperatures[7];
            btn9.Text = temperatures[8]; btn10.Text = temperatures[9]; btn11.Text = temperatures[10]; btn12.Text = temperatures[11];
            btn13.Text = temperatures[12]; btn14.Text = temperatures[13]; btn15.Text = temperatures[14]; btn16.Text = temperatures[15];
            btn17.Text = temperatures[16]; btn18.Text = temperatures[17]; btn19.Text = temperatures[18]; btn20.Text = temperatures[19];
            btn21.Text = temperatures[20]; btn22.Text = temperatures[21]; btn23.Text = temperatures[22]; btn24.Text = temperatures[23];
            btn25.Text = temperatures[24]; btn26.Text = temperatures[25]; btn27.Text = temperatures[26]; btn28.Text = temperatures[27];
            btn29.Text = temperatures[28]; btn30.Text = temperatures[29]; btn31.Text = temperatures[30]; btn32.Text = temperatures[31];
            btn33.Text = temperatures[32]; btn34.Text = temperatures[33]; btn35.Text = temperatures[34]; btn36.Text = temperatures[35];
            btn37.Text = temperatures[36]; btn38.Text = temperatures[37]; btn39.Text = temperatures[38]; btn40.Text = temperatures[39];
            btn41.Text = temperatures[40]; btn42.Text = temperatures[41]; btn43.Text = temperatures[42]; btn44.Text = temperatures[43];
            btn45.Text = temperatures[44]; btn46.Text = temperatures[45]; btn47.Text = temperatures[46]; btn48.Text = temperatures[47];
            btn49.Text = temperatures[48]; btn50.Text = temperatures[49]; btn51.Text = temperatures[50]; btn52.Text = temperatures[51];
            btn53.Text = temperatures[52]; btn54.Text = temperatures[53]; btn55.Text = temperatures[54]; btn56.Text = temperatures[55];
            btn57.Text = temperatures[56]; btn58.Text = temperatures[57]; btn59.Text = temperatures[58]; btn60.Text = temperatures[59];
            btn61.Text = temperatures[60]; btn62.Text = temperatures[61]; btn63.Text = temperatures[62]; btn64.Text = temperatures[63];

            // Color visualization:

            // Double array for comparing temperature values to corresponding color.
            double[] temperaturesDouble = new double[temperatures.Length];

            for (int i = 0; i < temperatures.Length; i++)
            {
                // Converting string values to double.
                double.TryParse(temperatures[i], NumberStyles.Any, CultureInfo.InvariantCulture, out temperaturesDouble[i]);

                // Visualizing temperatures with colors that correspond the temperature's value.
                btn1.BackColor = TempColor(temperaturesDouble[0]); btn2.BackColor = TempColor(temperaturesDouble[1]);
                btn3.BackColor = TempColor(temperaturesDouble[2]); btn4.BackColor = TempColor(temperaturesDouble[3]);
                btn5.BackColor = TempColor(temperaturesDouble[4]); btn6.BackColor = TempColor(temperaturesDouble[5]);
                btn7.BackColor = TempColor(temperaturesDouble[6]); btn8.BackColor = TempColor(temperaturesDouble[7]);
                btn9.BackColor = TempColor(temperaturesDouble[8]); btn10.BackColor = TempColor(temperaturesDouble[9]);
                btn11.BackColor = TempColor(temperaturesDouble[10]); btn12.BackColor = TempColor(temperaturesDouble[11]);
                btn13.BackColor = TempColor(temperaturesDouble[12]); btn14.BackColor = TempColor(temperaturesDouble[13]);
                btn15.BackColor = TempColor(temperaturesDouble[14]); btn16.BackColor = TempColor(temperaturesDouble[15]);
                btn17.BackColor = TempColor(temperaturesDouble[16]); btn18.BackColor = TempColor(temperaturesDouble[17]);
                btn19.BackColor = TempColor(temperaturesDouble[18]); btn20.BackColor = TempColor(temperaturesDouble[19]);
                btn21.BackColor = TempColor(temperaturesDouble[22]); btn22.BackColor = TempColor(temperaturesDouble[21]);
                btn23.BackColor = TempColor(temperaturesDouble[22]); btn24.BackColor = TempColor(temperaturesDouble[23]);
                btn25.BackColor = TempColor(temperaturesDouble[24]); btn26.BackColor = TempColor(temperaturesDouble[25]);
                btn27.BackColor = TempColor(temperaturesDouble[26]); btn28.BackColor = TempColor(temperaturesDouble[27]);
                btn29.BackColor = TempColor(temperaturesDouble[28]); btn30.BackColor = TempColor(temperaturesDouble[29]);
                btn31.BackColor = TempColor(temperaturesDouble[30]); btn32.BackColor = TempColor(temperaturesDouble[31]);
                btn33.BackColor = TempColor(temperaturesDouble[32]); btn34.BackColor = TempColor(temperaturesDouble[33]);
                btn35.BackColor = TempColor(temperaturesDouble[34]); btn36.BackColor = TempColor(temperaturesDouble[35]);
                btn37.BackColor = TempColor(temperaturesDouble[36]); btn38.BackColor = TempColor(temperaturesDouble[37]);
                btn39.BackColor = TempColor(temperaturesDouble[38]); btn40.BackColor = TempColor(temperaturesDouble[39]);
                btn41.BackColor = TempColor(temperaturesDouble[40]); btn42.BackColor = TempColor(temperaturesDouble[41]);
                btn43.BackColor = TempColor(temperaturesDouble[42]); btn44.BackColor = TempColor(temperaturesDouble[43]);
                btn45.BackColor = TempColor(temperaturesDouble[44]); btn46.BackColor = TempColor(temperaturesDouble[45]);
                btn47.BackColor = TempColor(temperaturesDouble[46]); btn48.BackColor = TempColor(temperaturesDouble[47]);
                btn49.BackColor = TempColor(temperaturesDouble[48]); btn50.BackColor = TempColor(temperaturesDouble[49]);
                btn51.BackColor = TempColor(temperaturesDouble[50]); btn52.BackColor = TempColor(temperaturesDouble[51]);
                btn53.BackColor = TempColor(temperaturesDouble[52]); btn54.BackColor = TempColor(temperaturesDouble[53]);
                btn55.BackColor = TempColor(temperaturesDouble[54]); btn56.BackColor = TempColor(temperaturesDouble[55]);
                btn57.BackColor = TempColor(temperaturesDouble[56]); btn58.BackColor = TempColor(temperaturesDouble[57]);
                btn59.BackColor = TempColor(temperaturesDouble[58]); btn60.BackColor = TempColor(temperaturesDouble[59]);
                btn61.BackColor = TempColor(temperaturesDouble[60]); btn62.BackColor = TempColor(temperaturesDouble[61]);
                btn63.BackColor = TempColor(temperaturesDouble[62]); btn64.BackColor = TempColor(temperaturesDouble[63]);
            }

        }

        // Method which returns a color for visualizing the temperature data.
        private Color TempColor(double temperature)
        {
            if (temperature >= 50)
            {
                return Color.FromArgb(255, 0, 0);
            }
            else if (temperature >= 49 && temperature < 50)
            {
                return Color.FromArgb(255, 100, 0);
            }
            else if (temperature >= 48 && temperature < 49)
            {
                return Color.FromArgb(255, 150, 0);
            }
            else if (temperature >= 47 && temperature < 48)
            {
                return Color.FromArgb(255, 200, 20);
            }
            else if (temperature >= 46 && temperature < 47)
            {
                return Color.FromArgb(255, 255, 0);
            }
            else if (temperature >= 45 && temperature < 46)
            {
                return Color.FromArgb(200, 255, 0);
            }
            else if (temperature >= 44 && temperature < 45)
            {
                return Color.FromArgb(150, 255, 0);
            }
            else if (temperature >= 43 && temperature < 44)
            {
                return Color.FromArgb(100, 255, 0);
            }
            else if (temperature >= 42 && temperature < 43)
            {
                return Color.FromArgb(0, 255, 0);
            }
            else if (temperature >= 41 && temperature < 40)
            {
                return Color.FromArgb(0, 255, 100);
            }
            else if (temperature >= 40 && temperature < 41)
            {
                return Color.FromArgb(0, 255, 150);
            }
            else if (temperature >= 39 && temperature < 40)
            {
                return Color.FromArgb(0, 255, 200);
            }
            else if (temperature >= 38 && temperature < 39)
            {
                return Color.FromArgb(0, 255, 255);
            }
            else if (temperature >= 37 && temperature < 38)
            {
                return Color.FromArgb(0, 200, 255);
            }
            else if (temperature >= 36 && temperature < 37)
            {
                return Color.FromArgb(0, 150, 255);
            }
            else if (temperature >= 35 && temperature < 36)
            {
                return Color.FromArgb(0, 100, 255);
            }
            else if (temperature >= 34 && temperature < 35)
            {
                return Color.FromArgb(0, 0, 255);
            }
            else if (temperature >= 33 && temperature < 34)
            {
                return Color.FromArgb(100, 0, 255);
            }
            else if (temperature >= 32 && temperature < 33)
            {
                return Color.FromArgb(150, 0, 255);
            }
            else if (temperature >= 31 && temperature < 32)
            {
                return Color.FromArgb(200, 0, 255);
            }
            else if (temperature >= 30 && temperature < 31)
            {
                return Color.FromArgb(255, 0, 255);
            }
            else if (temperature >= 29 && temperature < 30)
            {
                return Color.FromArgb(255, 0, 200);
            }
            else if (temperature >= 28 && temperature < 29)
            {
                return Color.FromArgb(255, 0, 150);
            }
            else if (temperature < 28)
            {
                return Color.FromArgb(255, 0, 100);
            }
            else
                return Color.FromArgb(255, 255, 255);
        }

        public string AvgTemperature { get; set; }  // String to send data to the Main App.

        private void BtnSendRedBoard_Click(object sender, EventArgs e)
        {
            if (!_sendGoing)
            {
                _sendGoing = true;
                _sendTimer.Start();
                btnSendRedBoard.Text = "Stop Sending";
                Log.Information("Sending temperature data started.");
            }
            else
            {
                _sendGoing = false;
                _sendTimer.Stop();
                btnSendRedBoard.Text = "Send";
                AvgTemperature = null;
                Log.Information("Sending temperature data stopped.");
            }
        }

        private void sendDataTimer_Tick(object sender, EventArgs e)
        {
            AvgTemperature = txtCalculate.Text;
        }
        private void ArraySensor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_comPort != null)
            {
                if (_comPort.IsOpen)
                {
                    _comPort.Close();
                    _comPort = null;
                }
            }
        }
    }
    
}
