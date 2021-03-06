﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSensor
{
    /// <summary>
    /// This is the base class for all C# programs that communicate with hardware sensor.
    /// The main sensor communication Form class must be ancestor of BaseSensorForm class
    /// instead of usual Form class.
    /// 
    /// When creating a new C# project for your own sensor communication part, you need to
    /// include a reference to DLL generated by this project.
    /// </summary>
    public partial class BaseSensorForm : Form
    {
        public delegate void TemperatureSendHandler(object sender, TemperatureSentEventArgs e);
        public event TemperatureSendHandler OnTemperatureSent;

        protected void SendTemperature(double temperature)
        {
            if (OnTemperatureSent == null) return;

            TemperatureSentEventArgs e = new TemperatureSentEventArgs(temperature);
            OnTemperatureSent(this, e);
        }
    }

    public class TemperatureSentEventArgs : EventArgs
    {
        public double Temperature { get; private set; } = 0;

        public TemperatureSentEventArgs(double temperature)
        {
            Temperature = temperature;
        }
    }
}
