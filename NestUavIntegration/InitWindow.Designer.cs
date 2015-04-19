﻿namespace NestUavIntegration
{
    partial class InitWindow
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.msgSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.messageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.clearInfoBox = new System.Windows.Forms.Button();
            this.altitudeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rollBox = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pitchBox = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.yawBox = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.flightInfo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.vehicleMode = new System.Windows.Forms.Label();
            this.mavStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.armButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.testButton = new System.Windows.Forms.Button();
            this.nestUrlTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nestConnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.armedLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "14550";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listening Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Connect_Click);
            // 
            // msgSelect
            // 
            this.msgSelect.FormattingEnabled = true;
            this.msgSelect.Location = new System.Drawing.Point(12, 448);
            this.msgSelect.Name = "msgSelect";
            this.msgSelect.Size = new System.Drawing.Size(189, 21);
            this.msgSelect.TabIndex = 3;
            this.msgSelect.SelectedIndexChanged += new System.EventHandler(this.msgSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Construct Message Manually";
            // 
            // messageLayout
            // 
            this.messageLayout.ColumnCount = 3;
            this.messageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.messageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.messageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.messageLayout.Location = new System.Drawing.Point(18, 475);
            this.messageLayout.Name = "messageLayout";
            this.messageLayout.RowCount = 8;
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messageLayout.Size = new System.Drawing.Size(321, 94);
            this.messageLayout.TabIndex = 5;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(207, 448);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(117, 21);
            this.sendMessageButton.TabIndex = 6;
            this.sendMessageButton.Text = "Send Message";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.SystemColors.Info;
            this.infoBox.Location = new System.Drawing.Point(381, 6);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoBox.Size = new System.Drawing.Size(495, 521);
            this.infoBox.TabIndex = 7;
            // 
            // clearInfoBox
            // 
            this.clearInfoBox.Location = new System.Drawing.Point(381, 546);
            this.clearInfoBox.Name = "clearInfoBox";
            this.clearInfoBox.Size = new System.Drawing.Size(495, 23);
            this.clearInfoBox.TabIndex = 8;
            this.clearInfoBox.Text = "Clear";
            this.clearInfoBox.UseVisualStyleBackColor = true;
            this.clearInfoBox.Click += new System.EventHandler(this.ClearInfoBox_Click);
            // 
            // altitudeBox
            // 
            this.altitudeBox.BackColor = System.Drawing.SystemColors.Control;
            this.altitudeBox.Location = new System.Drawing.Point(40, 95);
            this.altitudeBox.Name = "altitudeBox";
            this.altitudeBox.ReadOnly = true;
            this.altitudeBox.Size = new System.Drawing.Size(100, 20);
            this.altitudeBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Altitude";
            // 
            // rollBox
            // 
            this.rollBox.AutoSize = true;
            this.rollBox.Location = new System.Drawing.Point(78, 132);
            this.rollBox.Name = "rollBox";
            this.rollBox.Size = new System.Drawing.Size(25, 13);
            this.rollBox.TabIndex = 12;
            this.rollBox.Text = "Roll";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(40, 148);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 11;
            // 
            // pitchBox
            // 
            this.pitchBox.AutoSize = true;
            this.pitchBox.Location = new System.Drawing.Point(78, 188);
            this.pitchBox.Name = "pitchBox";
            this.pitchBox.Size = new System.Drawing.Size(31, 13);
            this.pitchBox.TabIndex = 14;
            this.pitchBox.Text = "Pitch";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(40, 204);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 13;
            // 
            // yawBox
            // 
            this.yawBox.AutoSize = true;
            this.yawBox.Location = new System.Drawing.Point(78, 245);
            this.yawBox.Name = "yawBox";
            this.yawBox.Size = new System.Drawing.Size(28, 13);
            this.yawBox.TabIndex = 16;
            this.yawBox.Text = "Yaw";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(40, 261);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 15;
            // 
            // flightInfo
            // 
            this.flightInfo.AutoSize = true;
            this.flightInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flightInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightInfo.Location = new System.Drawing.Point(23, 29);
            this.flightInfo.Name = "flightInfo";
            this.flightInfo.Size = new System.Drawing.Size(147, 24);
            this.flightInfo.TabIndex = 18;
            this.flightInfo.Text = "Flight Infomation";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(2, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(893, 604);
            this.tabControl.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.armedLabel);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.vehicleMode);
            this.tabPage1.Controls.Add(this.mavStatus);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.armButton);
            this.tabPage1.Controls.Add(this.infoBox);
            this.tabPage1.Controls.Add(this.clearInfoBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.sendMessageButton);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.messageLayout);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.msgSelect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // vehicleMode
            // 
            this.vehicleMode.AutoSize = true;
            this.vehicleMode.Location = new System.Drawing.Point(102, 64);
            this.vehicleMode.Name = "vehicleMode";
            this.vehicleMode.Size = new System.Drawing.Size(53, 13);
            this.vehicleMode.TabIndex = 13;
            this.vehicleMode.Text = "Unknown";
            // 
            // mavStatus
            // 
            this.mavStatus.AutoSize = true;
            this.mavStatus.Location = new System.Drawing.Point(102, 51);
            this.mavStatus.Name = "mavStatus";
            this.mavStatus.Size = new System.Drawing.Size(79, 13);
            this.mavStatus.TabIndex = 12;
            this.mavStatus.Text = "Not Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Vehicle Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mavlink Status:";
            // 
            // armButton
            // 
            this.armButton.Enabled = false;
            this.armButton.Location = new System.Drawing.Point(289, 17);
            this.armButton.Name = "armButton";
            this.armButton.Size = new System.Drawing.Size(75, 23);
            this.armButton.TabIndex = 9;
            this.armButton.Text = "Arm!";
            this.armButton.UseVisualStyleBackColor = true;
            this.armButton.Click += new System.EventHandler(this.armButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flightInfo);
            this.tabPage2.Controls.Add(this.altitudeBox);
            this.tabPage2.Controls.Add(this.yawBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.pitchBox);
            this.tabPage2.Controls.Add(this.rollBox);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 578);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flight State";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.testButton);
            this.tabPage3.Controls.Add(this.nestUrlTextBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.nestConnect);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(885, 578);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "NEST";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // testButton
            // 
            this.testButton.Enabled = false;
            this.testButton.Location = new System.Drawing.Point(9, 51);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // nestUrlTextBox
            // 
            this.nestUrlTextBox.Location = new System.Drawing.Point(73, 13);
            this.nestUrlTextBox.Name = "nestUrlTextBox";
            this.nestUrlTextBox.Size = new System.Drawing.Size(158, 20);
            this.nestUrlTextBox.TabIndex = 2;
            this.nestUrlTextBox.Text = "http://localhost:53130";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "NEST URL";
            // 
            // nestConnect
            // 
            this.nestConnect.Location = new System.Drawing.Point(237, 11);
            this.nestConnect.Name = "nestConnect";
            this.nestConnect.Size = new System.Drawing.Size(75, 23);
            this.nestConnect.TabIndex = 0;
            this.nestConnect.Text = "Connect";
            this.nestConnect.UseVisualStyleBackColor = true;
            this.nestConnect.Click += new System.EventHandler(this.nestConnect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Armed:";
            // 
            // armedLabel
            // 
            this.armedLabel.AutoSize = true;
            this.armedLabel.Location = new System.Drawing.Point(102, 77);
            this.armedLabel.Name = "armedLabel";
            this.armedLabel.Size = new System.Drawing.Size(57, 13);
            this.armedLabel.TabIndex = 15;
            this.armedLabel.Text = "Not Armed";
            // 
            // InitWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 603);
            this.Controls.Add(this.tabControl);
            this.Name = "InitWindow";
            this.Text = "NEST Mavlink Adapter";
            this.Load += new System.EventHandler(this.InitWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox msgSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel messageLayout;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Button clearInfoBox;
        private System.Windows.Forms.TextBox altitudeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label rollBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label pitchBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label yawBox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label flightInfo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button armButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox nestUrlTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button nestConnect;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label vehicleMode;
        private System.Windows.Forms.Label mavStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label armedLabel;
        private System.Windows.Forms.Label label7;
    }
}

