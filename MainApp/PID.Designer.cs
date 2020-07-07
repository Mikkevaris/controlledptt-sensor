namespace MainApp
{
    partial class PID
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
            this.gbPID = new System.Windows.Forms.GroupBox();
            this.gmPIDParams = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCalcCurrent = new System.Windows.Forms.TextBox();
            this.nudDGain = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nudPGain = new System.Windows.Forms.NumericUpDown();
            this.nudIGain = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.txtbPIDTime = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.gbTargetTemp = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbUseCalObjTemp = new System.Windows.Forms.CheckBox();
            this.nudTargetT = new System.Windows.Forms.NumericUpDown();
            this.txtPIDStatus = new System.Windows.Forms.TextBox();
            this.bPIDStart = new System.Windows.Forms.Button();
            this.gbPID.SuspendLayout();
            this.gmPIDParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGain)).BeginInit();
            this.gbTargetTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetT)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPID
            // 
            this.gbPID.Controls.Add(this.gmPIDParams);
            this.gbPID.Controls.Add(this.txtbPIDTime);
            this.gbPID.Controls.Add(this.label31);
            this.gbPID.Controls.Add(this.gbTargetTemp);
            this.gbPID.Controls.Add(this.txtPIDStatus);
            this.gbPID.Controls.Add(this.bPIDStart);
            this.gbPID.Location = new System.Drawing.Point(12, 6);
            this.gbPID.Name = "gbPID";
            this.gbPID.Size = new System.Drawing.Size(248, 378);
            this.gbPID.TabIndex = 41;
            this.gbPID.TabStop = false;
            this.gbPID.Text = "PID control";
            // 
            // gmPIDParams
            // 
            this.gmPIDParams.Controls.Add(this.label24);
            this.gmPIDParams.Controls.Add(this.label21);
            this.gmPIDParams.Controls.Add(this.txtCalcCurrent);
            this.gmPIDParams.Controls.Add(this.nudDGain);
            this.gmPIDParams.Controls.Add(this.label16);
            this.gmPIDParams.Controls.Add(this.label18);
            this.gmPIDParams.Controls.Add(this.nudPGain);
            this.gmPIDParams.Controls.Add(this.nudIGain);
            this.gmPIDParams.Controls.Add(this.label17);
            this.gmPIDParams.Location = new System.Drawing.Point(7, 202);
            this.gmPIDParams.Name = "gmPIDParams";
            this.gmPIDParams.Size = new System.Drawing.Size(235, 164);
            this.gmPIDParams.TabIndex = 29;
            this.gmPIDParams.TabStop = false;
            this.gmPIDParams.Text = "PID parameters";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(206, 123);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "A";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 123);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "Calculated Current";
            // 
            // txtCalcCurrent
            // 
            this.txtCalcCurrent.Location = new System.Drawing.Point(105, 120);
            this.txtCalcCurrent.Name = "txtCalcCurrent";
            this.txtCalcCurrent.ReadOnly = true;
            this.txtCalcCurrent.Size = new System.Drawing.Size(101, 20);
            this.txtCalcCurrent.TabIndex = 21;
            this.txtCalcCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudDGain
            // 
            this.nudDGain.Location = new System.Drawing.Point(105, 75);
            this.nudDGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudDGain.Name = "nudDGain";
            this.nudDGain.Size = new System.Drawing.Size(118, 20);
            this.nudDGain.TabIndex = 26;
            this.nudDGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Proportional Gain";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 79);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "Differential Gain";
            // 
            // nudPGain
            // 
            this.nudPGain.Location = new System.Drawing.Point(105, 23);
            this.nudPGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudPGain.Name = "nudPGain";
            this.nudPGain.Size = new System.Drawing.Size(118, 20);
            this.nudPGain.TabIndex = 23;
            this.nudPGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPGain.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // nudIGain
            // 
            this.nudIGain.Location = new System.Drawing.Point(105, 49);
            this.nudIGain.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIGain.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudIGain.Name = "nudIGain";
            this.nudIGain.Size = new System.Drawing.Size(118, 20);
            this.nudIGain.TabIndex = 24;
            this.nudIGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIGain.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Integral Gain";
            // 
            // txtbPIDTime
            // 
            this.txtbPIDTime.Location = new System.Drawing.Point(114, 84);
            this.txtbPIDTime.Name = "txtbPIDTime";
            this.txtbPIDTime.ReadOnly = true;
            this.txtbPIDTime.Size = new System.Drawing.Size(118, 20);
            this.txtbPIDTime.TabIndex = 24;
            this.txtbPIDTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(13, 87);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(73, 13);
            this.label31.TabIndex = 23;
            this.label31.Text = "Running Time";
            // 
            // gbTargetTemp
            // 
            this.gbTargetTemp.Controls.Add(this.label19);
            this.gbTargetTemp.Controls.Add(this.cbUseCalObjTemp);
            this.gbTargetTemp.Controls.Add(this.nudTargetT);
            this.gbTargetTemp.Location = new System.Drawing.Point(7, 114);
            this.gbTargetTemp.Name = "gbTargetTemp";
            this.gbTargetTemp.Size = new System.Drawing.Size(235, 82);
            this.gbTargetTemp.TabIndex = 28;
            this.gbTargetTemp.TabStop = false;
            this.gbTargetTemp.Text = "Target Temperature";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Temperature";
            // 
            // cbUseCalObjTemp
            // 
            this.cbUseCalObjTemp.AutoSize = true;
            this.cbUseCalObjTemp.Checked = true;
            this.cbUseCalObjTemp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseCalObjTemp.Location = new System.Drawing.Point(6, 21);
            this.cbUseCalObjTemp.Name = "cbUseCalObjTemp";
            this.cbUseCalObjTemp.Size = new System.Drawing.Size(192, 17);
            this.cbUseCalObjTemp.TabIndex = 30;
            this.cbUseCalObjTemp.Text = "Use Calibrated Object Temperature";
            this.cbUseCalObjTemp.UseVisualStyleBackColor = true;
            // 
            // nudTargetT
            // 
            this.nudTargetT.DecimalPlaces = 1;
            this.nudTargetT.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudTargetT.Location = new System.Drawing.Point(107, 44);
            this.nudTargetT.Name = "nudTargetT";
            this.nudTargetT.Size = new System.Drawing.Size(118, 20);
            this.nudTargetT.TabIndex = 28;
            this.nudTargetT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPIDStatus
            // 
            this.txtPIDStatus.BackColor = System.Drawing.Color.Red;
            this.txtPIDStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPIDStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPIDStatus.Location = new System.Drawing.Point(13, 57);
            this.txtPIDStatus.Name = "txtPIDStatus";
            this.txtPIDStatus.ReadOnly = true;
            this.txtPIDStatus.Size = new System.Drawing.Size(219, 20);
            this.txtPIDStatus.TabIndex = 21;
            this.txtPIDStatus.Text = "PID Control Off";
            this.txtPIDStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bPIDStart
            // 
            this.bPIDStart.Location = new System.Drawing.Point(13, 23);
            this.bPIDStart.Name = "bPIDStart";
            this.bPIDStart.Size = new System.Drawing.Size(219, 28);
            this.bPIDStart.TabIndex = 0;
            this.bPIDStart.Text = "Start PID Control";
            this.bPIDStart.UseVisualStyleBackColor = true;
            // 
            // PID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 395);
            this.Controls.Add(this.gbPID);
            this.Name = "PID";
            this.Text = "PID";
            this.gbPID.ResumeLayout(false);
            this.gbPID.PerformLayout();
            this.gmPIDParams.ResumeLayout(false);
            this.gmPIDParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGain)).EndInit();
            this.gbTargetTemp.ResumeLayout(false);
            this.gbTargetTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPID;
        private System.Windows.Forms.GroupBox gmPIDParams;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCalcCurrent;
        private System.Windows.Forms.NumericUpDown nudDGain;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudPGain;
        private System.Windows.Forms.NumericUpDown nudIGain;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtbPIDTime;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox gbTargetTemp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbUseCalObjTemp;
        private System.Windows.Forms.NumericUpDown nudTargetT;
        private System.Windows.Forms.TextBox txtPIDStatus;
        private System.Windows.Forms.Button bPIDStart;
    }
}