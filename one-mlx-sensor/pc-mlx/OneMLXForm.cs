﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseSensor;

namespace PcMlx
{
    public partial class OneMLXForm : BaseSensorForm
    {
        // COM port connection vars.
        private SerialPort _comPort = null; // Com port connection.

        private string _recieved = string.Empty; // String to keep recieved data.

        private bool _comConnected = false; // Variable indicating if connection is open.

        public OneMLXForm()
        {
            InitializeComponent();
            cbBaudRate.SelectedIndex = 6;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_comPort.BytesToRead > 0)  // Reads all available serial input.
                                              // Without this there will be a lag displaying the data.
            {
                try
                {
                    _recieved = _comPort.ReadLine(); // ReadExisting();
                                                     // One line must contain "object_temperature ambient_temperature" in Celcius.
                    this.Invoke(new EventHandler(DisplayData)); // Display recieved temperatures.
                }
                catch { }
            }
            
        }

        private void DisplayData(object sender, EventArgs e)
        {

            txtAllRecievedData.AppendText(_recieved);
            txtAllRecievedData.ScrollToCaret();

            var temperatures = _recieved.Split(' ');
            txtObjTemp.Text = temperatures[0];
            txtAmbTemp.Text = temperatures[1];            
        }

        private void btnGetComPorts_Click(object sender, EventArgs e)
        {
            cbPorts.Items.Clear();
            var comPortNames = SerialPort.GetPortNames();
            if (comPortNames.Length > 0)
            {
                cbPorts.Items.AddRange(comPortNames);
                cbPorts.SelectedIndex = 0;
            }
        }

        private void btnConnRedBoard_Click(object sender, EventArgs e)
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

            }          
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtAllRecievedData.Clear();
        }
    }
}
