using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using BaseSensor;
using System.Globalization;
using Serilog;

namespace twoMlxSensors

{
    public partial class TwoMLXForm : BaseSensorForm
    {
        // COM port connection vars.
        private SerialPort _comPort = null; // COM port connection.

        private string _received = string.Empty; // String to keep recieved data.

        private bool _comConnected = false; // Variable indicating if connection is open.

        private bool _sendGoing = false;

        private Timer _sendTimer = new Timer()
        {
            Interval = 1000
        };

        public TwoMLXForm()
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
            txtAllRecievedData.AppendText(_received);
            txtAllRecievedData.ScrollToCaret();

            var temperatures = _received.Split(' ');
            txtObj1Temp.Text = temperatures[0];
            txtAmb1Temp.Text = temperatures[1];
            txtObj2Temp.Text = temperatures[2];
            txtAmb2Temp.Text = temperatures[3];
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
            txtAllRecievedData.Clear(); 
        }

        // Two strings to send data to the Main App.
        public string AvgObjTemperature { get; set; }
        public string AvgAmbTemperature { get; set; }
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
                Log.Information("Sending temperature data stopped.");
            }
        }
        private void sendDataTimer_Tick(object sender, EventArgs e)
        {
            double.TryParse(txtObj1Temp.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double obj1Temp);
            double.TryParse(txtObj2Temp.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double obj2Temp);
            double.TryParse(txtAmb1Temp.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double amb1temp);
            double.TryParse(txtAmb2Temp.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double amb2temp);

            AvgObjTemperature = ((obj1Temp + obj2Temp) / 2).ToString("F");
            AvgAmbTemperature = ((amb1temp + amb2temp) / 2).ToString("F");
            //Console.WriteLine(AvgObjTemperature);
        }

   
    }
}
