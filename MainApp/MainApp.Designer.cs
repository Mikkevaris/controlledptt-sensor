namespace MainApp
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbTempFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectTempPath = new System.Windows.Forms.Button();
            this.txtTempFileName = new System.Windows.Forms.TextBox();
            this.pltObjTemp = new OxyPlot.WindowsForms.PlotView();
            this.gbExperiment = new System.Windows.Forms.GroupBox();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.nudExpTime = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.txtExpTime = new System.Windows.Forms.TextBox();
            this.rbOnlySaveTemp = new System.Windows.Forms.RadioButton();
            this.txtExperimentStarted = new System.Windows.Forms.TextBox();
            this.btnStartExperiment = new System.Windows.Forms.Button();
            this.cbSaveData = new System.Windows.Forms.CheckBox();
            this.btnPIDControl = new System.Windows.Forms.Button();
            this.rbPIDControl = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rbNoPIDControl = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnCancelSelection = new System.Windows.Forms.Button();
            this.btnSelectSensor = new System.Windows.Forms.Button();
            this.cmbSensors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNoCalibration = new System.Windows.Forms.CheckBox();
            this.btnCalibration = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.pltLaserCurrent = new OxyPlot.WindowsForms.PlotView();
            this.pltAmbTemp = new OxyPlot.WindowsForms.PlotView();
            this.groupBox1.SuspendLayout();
            this.gbExperiment.SuspendLayout();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbTempFilePath);
            this.groupBox1.Controls.Add(this.btnSelectTempPath);
            this.groupBox1.Controls.Add(this.txtTempFileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 78);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Temperature Data";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "File Name";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tbTempFilePath
            // 
            this.tbTempFilePath.Location = new System.Drawing.Point(127, 19);
            this.tbTempFilePath.Name = "tbTempFilePath";
            this.tbTempFilePath.Size = new System.Drawing.Size(352, 20);
            this.tbTempFilePath.TabIndex = 16;
            // 
            // btnSelectTempPath
            // 
            this.btnSelectTempPath.Location = new System.Drawing.Point(6, 17);
            this.btnSelectTempPath.Name = "btnSelectTempPath";
            this.btnSelectTempPath.Size = new System.Drawing.Size(115, 23);
            this.btnSelectTempPath.TabIndex = 18;
            this.btnSelectTempPath.Text = "Select Path";
            this.btnSelectTempPath.UseVisualStyleBackColor = true;
            this.btnSelectTempPath.Click += new System.EventHandler(this.BtnSelectTempPath_Click);
            // 
            // txtTempFileName
            // 
            this.txtTempFileName.Location = new System.Drawing.Point(127, 48);
            this.txtTempFileName.Name = "txtTempFileName";
            this.txtTempFileName.Size = new System.Drawing.Size(352, 20);
            this.txtTempFileName.TabIndex = 19;
            // 
            // pltObjTemp
            // 
            this.pltObjTemp.Location = new System.Drawing.Point(504, 12);
            this.pltObjTemp.Name = "pltObjTemp";
            this.pltObjTemp.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltObjTemp.Size = new System.Drawing.Size(433, 240);
            this.pltObjTemp.TabIndex = 43;
            this.pltObjTemp.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltObjTemp.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltObjTemp.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // gbExperiment
            // 
            this.gbExperiment.Controls.Add(this.gbControls);
            this.gbExperiment.Controls.Add(this.groupBox6);
            this.gbExperiment.Location = new System.Drawing.Point(12, 96);
            this.gbExperiment.Name = "gbExperiment";
            this.gbExperiment.Size = new System.Drawing.Size(486, 676);
            this.gbExperiment.TabIndex = 47;
            this.gbExperiment.TabStop = false;
            this.gbExperiment.Text = "Experiment";
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.label26);
            this.gbControls.Controls.Add(this.nudExpTime);
            this.gbControls.Controls.Add(this.label25);
            this.gbControls.Controls.Add(this.txtExpTime);
            this.gbControls.Controls.Add(this.rbOnlySaveTemp);
            this.gbControls.Controls.Add(this.txtExperimentStarted);
            this.gbControls.Controls.Add(this.btnStartExperiment);
            this.gbControls.Controls.Add(this.cbSaveData);
            this.gbControls.Controls.Add(this.btnPIDControl);
            this.gbControls.Controls.Add(this.rbPIDControl);
            this.gbControls.Controls.Add(this.groupBox3);
            this.gbControls.Controls.Add(this.rbNoPIDControl);
            this.gbControls.Location = new System.Drawing.Point(6, 119);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(475, 551);
            this.gbControls.TabIndex = 61;
            this.gbControls.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(302, 424);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 72;
            this.label26.Text = "Time";
            // 
            // nudExpTime
            // 
            this.nudExpTime.Location = new System.Drawing.Point(338, 420);
            this.nudExpTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudExpTime.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudExpTime.Name = "nudExpTime";
            this.nudExpTime.Size = new System.Drawing.Size(98, 20);
            this.nudExpTime.TabIndex = 69;
            this.nudExpTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudExpTime.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(442, 424);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(24, 13);
            this.label25.TabIndex = 71;
            this.label25.Text = "Min";
            // 
            // txtExpTime
            // 
            this.txtExpTime.Location = new System.Drawing.Point(338, 420);
            this.txtExpTime.Name = "txtExpTime";
            this.txtExpTime.ReadOnly = true;
            this.txtExpTime.Size = new System.Drawing.Size(98, 20);
            this.txtExpTime.TabIndex = 70;
            this.txtExpTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpTime.Visible = false;
            // 
            // rbOnlySaveTemp
            // 
            this.rbOnlySaveTemp.AutoSize = true;
            this.rbOnlySaveTemp.Checked = true;
            this.rbOnlySaveTemp.Location = new System.Drawing.Point(121, 415);
            this.rbOnlySaveTemp.Name = "rbOnlySaveTemp";
            this.rbOnlySaveTemp.Size = new System.Drawing.Size(137, 17);
            this.rbOnlySaveTemp.TabIndex = 64;
            this.rbOnlySaveTemp.TabStop = true;
            this.rbOnlySaveTemp.Text = "Only Save Temperature";
            this.rbOnlySaveTemp.UseVisualStyleBackColor = true;
            // 
            // txtExperimentStarted
            // 
            this.txtExperimentStarted.BackColor = System.Drawing.Color.Red;
            this.txtExperimentStarted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExperimentStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtExperimentStarted.Location = new System.Drawing.Point(240, 518);
            this.txtExperimentStarted.Name = "txtExperimentStarted";
            this.txtExperimentStarted.ReadOnly = true;
            this.txtExperimentStarted.Size = new System.Drawing.Size(219, 20);
            this.txtExperimentStarted.TabIndex = 62;
            this.txtExperimentStarted.Text = "Experiment Not Started";
            this.txtExperimentStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStartExperiment
            // 
            this.btnStartExperiment.Location = new System.Drawing.Point(240, 485);
            this.btnStartExperiment.Name = "btnStartExperiment";
            this.btnStartExperiment.Size = new System.Drawing.Size(219, 28);
            this.btnStartExperiment.TabIndex = 63;
            this.btnStartExperiment.Text = "Start Experiment";
            this.btnStartExperiment.UseVisualStyleBackColor = true;
            this.btnStartExperiment.Click += new System.EventHandler(this.BStartExperiment_Click);
            // 
            // cbSaveData
            // 
            this.cbSaveData.AutoSize = true;
            this.cbSaveData.Checked = true;
            this.cbSaveData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveData.Location = new System.Drawing.Point(298, 446);
            this.cbSaveData.Name = "cbSaveData";
            this.cbSaveData.Size = new System.Drawing.Size(108, 17);
            this.cbSaveData.TabIndex = 58;
            this.cbSaveData.Text = "Save Data to File";
            this.cbSaveData.UseVisualStyleBackColor = true;
            // 
            // btnPIDControl
            // 
            this.btnPIDControl.Location = new System.Drawing.Point(9, 20);
            this.btnPIDControl.Name = "btnPIDControl";
            this.btnPIDControl.Size = new System.Drawing.Size(204, 40);
            this.btnPIDControl.TabIndex = 67;
            this.btnPIDControl.Text = "PID Control";
            this.btnPIDControl.UseVisualStyleBackColor = true;
            this.btnPIDControl.Click += new System.EventHandler(this.BtnPIDControl_Click);
            // 
            // rbPIDControl
            // 
            this.rbPIDControl.AutoSize = true;
            this.rbPIDControl.Location = new System.Drawing.Point(9, 444);
            this.rbPIDControl.Name = "rbPIDControl";
            this.rbPIDControl.Size = new System.Drawing.Size(79, 17);
            this.rbPIDControl.TabIndex = 61;
            this.rbPIDControl.Text = "PID Control";
            this.rbPIDControl.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Location = new System.Drawing.Point(226, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 179);
            this.groupBox3.TabIndex = 65;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calibration Coeffitients for Object Temperature";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Location = new System.Drawing.Point(7, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(234, 71);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "To heat from 37oC";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(7, 47);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 13);
            this.label35.TabIndex = 32;
            this.label35.Text = "Intersept";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(105, 44);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(118, 20);
            this.textBox3.TabIndex = 31;
            this.textBox3.Text = "0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(7, 21);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(34, 13);
            this.label36.TabIndex = 30;
            this.label36.Text = "Slope";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(105, 18);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(118, 20);
            this.textBox4.TabIndex = 29;
            this.textBox4.Text = "0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(7, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(234, 71);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "To heat from 20oC";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(7, 47);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 13);
            this.label34.TabIndex = 32;
            this.label34.Text = "Intersept";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(118, 20);
            this.textBox2.TabIndex = 31;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(7, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(34, 13);
            this.label33.TabIndex = 30;
            this.label33.Text = "Slope";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbNoPIDControl
            // 
            this.rbNoPIDControl.AutoSize = true;
            this.rbNoPIDControl.Location = new System.Drawing.Point(9, 415);
            this.rbNoPIDControl.Name = "rbNoPIDControl";
            this.rbNoPIDControl.Size = new System.Drawing.Size(96, 17);
            this.rbNoPIDControl.TabIndex = 60;
            this.rbNoPIDControl.Text = "Simple Heating";
            this.rbNoPIDControl.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnCancelSelection);
            this.groupBox6.Controls.Add(this.btnSelectSensor);
            this.groupBox6.Controls.Add(this.cmbSensors);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.cbNoCalibration);
            this.groupBox6.Controls.Add(this.btnCalibration);
            this.groupBox6.Location = new System.Drawing.Point(6, 15);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(475, 105);
            this.groupBox6.TabIndex = 60;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sensor Selection and Calibration";
            // 
            // btnCancelSelection
            // 
            this.btnCancelSelection.Location = new System.Drawing.Point(105, 67);
            this.btnCancelSelection.Name = "btnCancelSelection";
            this.btnCancelSelection.Size = new System.Drawing.Size(85, 24);
            this.btnCancelSelection.TabIndex = 59;
            this.btnCancelSelection.Text = "Cancel";
            this.btnCancelSelection.UseVisualStyleBackColor = true;
            this.btnCancelSelection.Click += new System.EventHandler(this.BtnCancelSelection_Click);
            // 
            // btnSelectSensor
            // 
            this.btnSelectSensor.Location = new System.Drawing.Point(14, 67);
            this.btnSelectSensor.Name = "btnSelectSensor";
            this.btnSelectSensor.Size = new System.Drawing.Size(85, 24);
            this.btnSelectSensor.TabIndex = 58;
            this.btnSelectSensor.Text = "Select";
            this.btnSelectSensor.UseVisualStyleBackColor = true;
            this.btnSelectSensor.Click += new System.EventHandler(this.BtnSelectSensor_Click);
            // 
            // cmbSensors
            // 
            this.cmbSensors.FormattingEnabled = true;
            this.cmbSensors.Items.AddRange(new object[] {
            "MLX90621 Infrared (IR) sensor array",
            "MLX90614 Infrared Thermometer",
            "Two MLX90614 Infrared Thermometers"});
            this.cmbSensors.Location = new System.Drawing.Point(14, 40);
            this.cmbSensors.Name = "cmbSensors";
            this.cmbSensors.Size = new System.Drawing.Size(204, 21);
            this.cmbSensors.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Select Sensor:";
            // 
            // cbNoCalibration
            // 
            this.cbNoCalibration.AutoSize = true;
            this.cbNoCalibration.Location = new System.Drawing.Point(231, 75);
            this.cbNoCalibration.Name = "cbNoCalibration";
            this.cbNoCalibration.Size = new System.Drawing.Size(92, 17);
            this.cbNoCalibration.TabIndex = 54;
            this.cbNoCalibration.Text = "No Calibration";
            this.cbNoCalibration.UseVisualStyleBackColor = true;
            // 
            // btnCalibration
            // 
            this.btnCalibration.Location = new System.Drawing.Point(231, 39);
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.Size = new System.Drawing.Size(219, 30);
            this.btnCalibration.TabIndex = 51;
            this.btnCalibration.Text = "Calibration";
            this.btnCalibration.UseVisualStyleBackColor = true;
            this.btnCalibration.Click += new System.EventHandler(this.BtnCalibration_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 775);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Info";
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(11, 791);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(921, 65);
            this.rtbInfo.TabIndex = 48;
            this.rtbInfo.Text = "";
            // 
            // pltLaserCurrent
            // 
            this.pltLaserCurrent.Location = new System.Drawing.Point(504, 504);
            this.pltLaserCurrent.Name = "pltLaserCurrent";
            this.pltLaserCurrent.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltLaserCurrent.Size = new System.Drawing.Size(433, 240);
            this.pltLaserCurrent.TabIndex = 52;
            this.pltLaserCurrent.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltLaserCurrent.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltLaserCurrent.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // pltAmbTemp
            // 
            this.pltAmbTemp.Location = new System.Drawing.Point(504, 258);
            this.pltAmbTemp.Name = "pltAmbTemp";
            this.pltAmbTemp.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pltAmbTemp.Size = new System.Drawing.Size(433, 240);
            this.pltAmbTemp.TabIndex = 53;
            this.pltAmbTemp.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pltAmbTemp.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pltAmbTemp.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 868);
            this.Controls.Add(this.pltAmbTemp);
            this.Controls.Add(this.pltLaserCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.gbExperiment);
            this.Controls.Add(this.pltObjTemp);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainApp";
            this.Text = "MainApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbExperiment.ResumeLayout(false);
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExpTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbTempFilePath;
        private System.Windows.Forms.Button btnSelectTempPath;
        private System.Windows.Forms.TextBox txtTempFileName;
        private OxyPlot.WindowsForms.PlotView pltObjTemp;
        private System.Windows.Forms.GroupBox gbExperiment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.CheckBox cbNoCalibration;
        private System.Windows.Forms.Button btnCalibration;
        private System.Windows.Forms.Button btnCancelSelection;
        private System.Windows.Forms.Button btnSelectSensor;
        private System.Windows.Forms.ComboBox cmbSensors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private OxyPlot.WindowsForms.PlotView pltLaserCurrent;
        private OxyPlot.WindowsForms.PlotView pltAmbTemp;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.RadioButton rbOnlySaveTemp;
        private System.Windows.Forms.TextBox txtExperimentStarted;
        private System.Windows.Forms.Button btnStartExperiment;
        private System.Windows.Forms.CheckBox cbSaveData;
        private System.Windows.Forms.Button btnPIDControl;
        private System.Windows.Forms.RadioButton rbPIDControl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rbNoPIDControl;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown nudExpTime;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtExpTime;
    }
}

