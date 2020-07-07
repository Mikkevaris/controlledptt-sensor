﻿namespace twoMlxSensors
{
    partial class TwoMLXForm
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
            this.gbArduino = new System.Windows.Forms.GroupBox();
            this.txtAmb2Temp = new System.Windows.Forms.TextBox();
            this.txtObj2Temp = new System.Windows.Forms.TextBox();
            this.btnAmb2Temp = new System.Windows.Forms.Button();
            this.btnObj2Temp = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAllRecievedData = new System.Windows.Forms.RichTextBox();
            this.btnAmb1Temp = new System.Windows.Forms.Button();
            this.txtAmb1Temp = new System.Windows.Forms.TextBox();
            this.btnObj1Temp = new System.Windows.Forms.Button();
            this.txtObj1Temp = new System.Windows.Forms.TextBox();
            this.txtConnectedStatus = new System.Windows.Forms.TextBox();
            this.bBaudRate = new System.Windows.Forms.Button();
            this.btnSendRedBoard = new System.Windows.Forms.Button();
            this.btnGetComPorts = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnConnRedBoard = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.gbArduino.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArduino
            // 
            this.gbArduino.Controls.Add(this.txtAmb2Temp);
            this.gbArduino.Controls.Add(this.txtObj2Temp);
            this.gbArduino.Controls.Add(this.btnAmb2Temp);
            this.gbArduino.Controls.Add(this.btnObj2Temp);
            this.gbArduino.Controls.Add(this.btnClearData);
            this.gbArduino.Controls.Add(this.label3);
            this.gbArduino.Controls.Add(this.txtAllRecievedData);
            this.gbArduino.Controls.Add(this.btnAmb1Temp);
            this.gbArduino.Controls.Add(this.txtAmb1Temp);
            this.gbArduino.Controls.Add(this.btnObj1Temp);
            this.gbArduino.Controls.Add(this.txtObj1Temp);
            this.gbArduino.Controls.Add(this.txtConnectedStatus);
            this.gbArduino.Controls.Add(this.bBaudRate);
            this.gbArduino.Controls.Add(this.btnSendRedBoard);
            this.gbArduino.Controls.Add(this.btnGetComPorts);
            this.gbArduino.Controls.Add(this.cbPorts);
            this.gbArduino.Controls.Add(this.cbBaudRate);
            this.gbArduino.Controls.Add(this.btnConnRedBoard);
            this.gbArduino.Controls.Add(this.txtSend);
            this.gbArduino.Location = new System.Drawing.Point(13, 12);
            this.gbArduino.Name = "gbArduino";
            this.gbArduino.Size = new System.Drawing.Size(280, 411);
            this.gbArduino.TabIndex = 35;
            this.gbArduino.TabStop = false;
            this.gbArduino.Text = "Controller connection";
            // 
            // txtAmb2Temp
            // 
            this.txtAmb2Temp.Location = new System.Drawing.Point(127, 332);
            this.txtAmb2Temp.Name = "txtAmb2Temp";
            this.txtAmb2Temp.ReadOnly = true;
            this.txtAmb2Temp.Size = new System.Drawing.Size(145, 20);
            this.txtAmb2Temp.TabIndex = 26;
            // 
            // txtObj2Temp
            // 
            this.txtObj2Temp.Location = new System.Drawing.Point(127, 303);
            this.txtObj2Temp.Name = "txtObj2Temp";
            this.txtObj2Temp.ReadOnly = true;
            this.txtObj2Temp.Size = new System.Drawing.Size(145, 20);
            this.txtObj2Temp.TabIndex = 25;
            // 
            // btnAmb2Temp
            // 
            this.btnAmb2Temp.Location = new System.Drawing.Point(6, 330);
            this.btnAmb2Temp.Name = "btnAmb2Temp";
            this.btnAmb2Temp.Size = new System.Drawing.Size(115, 23);
            this.btnAmb2Temp.TabIndex = 24;
            this.btnAmb2Temp.Text = "Ambient 2";
            this.btnAmb2Temp.UseVisualStyleBackColor = true;
            // 
            // btnObj2Temp
            // 
            this.btnObj2Temp.Location = new System.Drawing.Point(6, 301);
            this.btnObj2Temp.Name = "btnObj2Temp";
            this.btnObj2Temp.Size = new System.Drawing.Size(115, 23);
            this.btnObj2Temp.TabIndex = 23;
            this.btnObj2Temp.Text = "Object 2";
            this.btnObj2Temp.UseVisualStyleBackColor = true;
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(231, 153);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(41, 84);
            this.btnClearData.TabIndex = 22;
            this.btnClearData.Text = "C\r\nl\r\ne\r\na\r\nr";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.BtnClearData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "All Received Data";
            // 
            // txtAllRecievedData
            // 
            this.txtAllRecievedData.Location = new System.Drawing.Point(6, 153);
            this.txtAllRecievedData.Name = "txtAllRecievedData";
            this.txtAllRecievedData.Size = new System.Drawing.Size(219, 84);
            this.txtAllRecievedData.TabIndex = 20;
            this.txtAllRecievedData.Text = "";
            // 
            // btnAmb1Temp
            // 
            this.btnAmb1Temp.Location = new System.Drawing.Point(6, 272);
            this.btnAmb1Temp.Name = "btnAmb1Temp";
            this.btnAmb1Temp.Size = new System.Drawing.Size(115, 23);
            this.btnAmb1Temp.TabIndex = 19;
            this.btnAmb1Temp.Text = "Ambient 1";
            this.btnAmb1Temp.UseVisualStyleBackColor = true;
            // 
            // txtAmb1Temp
            // 
            this.txtAmb1Temp.Location = new System.Drawing.Point(127, 274);
            this.txtAmb1Temp.Name = "txtAmb1Temp";
            this.txtAmb1Temp.ReadOnly = true;
            this.txtAmb1Temp.Size = new System.Drawing.Size(145, 20);
            this.txtAmb1Temp.TabIndex = 18;
            // 
            // btnObj1Temp
            // 
            this.btnObj1Temp.Location = new System.Drawing.Point(6, 243);
            this.btnObj1Temp.Name = "btnObj1Temp";
            this.btnObj1Temp.Size = new System.Drawing.Size(115, 23);
            this.btnObj1Temp.TabIndex = 17;
            this.btnObj1Temp.Text = "Object 1";
            this.btnObj1Temp.UseVisualStyleBackColor = true;
            // 
            // txtObj1Temp
            // 
            this.txtObj1Temp.Location = new System.Drawing.Point(127, 245);
            this.txtObj1Temp.Name = "txtObj1Temp";
            this.txtObj1Temp.ReadOnly = true;
            this.txtObj1Temp.Size = new System.Drawing.Size(145, 20);
            this.txtObj1Temp.TabIndex = 16;
            // 
            // txtConnectedStatus
            // 
            this.txtConnectedStatus.BackColor = System.Drawing.Color.Red;
            this.txtConnectedStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConnectedStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConnectedStatus.Location = new System.Drawing.Point(127, 82);
            this.txtConnectedStatus.Name = "txtConnectedStatus";
            this.txtConnectedStatus.ReadOnly = true;
            this.txtConnectedStatus.Size = new System.Drawing.Size(145, 20);
            this.txtConnectedStatus.TabIndex = 15;
            this.txtConnectedStatus.Text = "Not Connected";
            this.txtConnectedStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bBaudRate
            // 
            this.bBaudRate.Location = new System.Drawing.Point(6, 51);
            this.bBaudRate.Name = "bBaudRate";
            this.bBaudRate.Size = new System.Drawing.Size(115, 23);
            this.bBaudRate.TabIndex = 14;
            this.bBaudRate.Text = "Baud Rate";
            this.bBaudRate.UseVisualStyleBackColor = true;
            // 
            // btnSendRedBoard
            // 
            this.btnSendRedBoard.Location = new System.Drawing.Point(6, 109);
            this.btnSendRedBoard.Name = "btnSendRedBoard";
            this.btnSendRedBoard.Size = new System.Drawing.Size(115, 23);
            this.btnSendRedBoard.TabIndex = 5;
            this.btnSendRedBoard.Text = "Send";
            this.btnSendRedBoard.UseVisualStyleBackColor = true;
            this.btnSendRedBoard.Click += new System.EventHandler(this.BtnSendRedBoard_Click);
            // 
            // btnGetComPorts
            // 
            this.btnGetComPorts.Location = new System.Drawing.Point(6, 22);
            this.btnGetComPorts.Name = "btnGetComPorts";
            this.btnGetComPorts.Size = new System.Drawing.Size(115, 23);
            this.btnGetComPorts.TabIndex = 0;
            this.btnGetComPorts.Text = "Get COM ports";
            this.btnGetComPorts.UseVisualStyleBackColor = true;
            this.btnGetComPorts.Click += new System.EventHandler(this.BtnGetComPorts_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(127, 22);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(145, 21);
            this.cbPorts.TabIndex = 2;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200 "});
            this.cbBaudRate.Location = new System.Drawing.Point(127, 53);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(145, 21);
            this.cbBaudRate.TabIndex = 13;
            // 
            // btnConnRedBoard
            // 
            this.btnConnRedBoard.Location = new System.Drawing.Point(6, 80);
            this.btnConnRedBoard.Name = "btnConnRedBoard";
            this.btnConnRedBoard.Size = new System.Drawing.Size(115, 23);
            this.btnConnRedBoard.TabIndex = 3;
            this.btnConnRedBoard.Text = "Connect to Board";
            this.btnConnRedBoard.UseVisualStyleBackColor = true;
            this.btnConnRedBoard.Click += new System.EventHandler(this.BtnConnRedBoard_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(127, 111);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(145, 20);
            this.txtSend.TabIndex = 4;
            // 
            // TwoMLXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 435);
            this.Controls.Add(this.gbArduino);
            this.Name = "TwoMLXForm";
            this.Text = "Two MLX sensors";
            this.gbArduino.ResumeLayout(false);
            this.gbArduino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArduino;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtAllRecievedData;
        private System.Windows.Forms.Button btnAmb1Temp;
        private System.Windows.Forms.TextBox txtAmb1Temp;
        private System.Windows.Forms.TextBox txtObj1Temp;
        private System.Windows.Forms.TextBox txtConnectedStatus;
        private System.Windows.Forms.Button bBaudRate;
        private System.Windows.Forms.Button btnSendRedBoard;
        private System.Windows.Forms.Button btnGetComPorts;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Button btnConnRedBoard;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtObj2Temp;
        private System.Windows.Forms.Button btnAmb2Temp;
        private System.Windows.Forms.Button btnObj2Temp;
        private System.Windows.Forms.Button btnObj1Temp;
        private System.Windows.Forms.TextBox txtAmb2Temp;
    }
}

