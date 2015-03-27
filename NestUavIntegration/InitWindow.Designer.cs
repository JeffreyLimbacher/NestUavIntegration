namespace NestUavIntegration
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
            this.armButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(138, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "14550";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listening Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Connect_Click);
            // 
            // msgSelect
            // 
            this.msgSelect.FormattingEnabled = true;
            this.msgSelect.Location = new System.Drawing.Point(27, 117);
            this.msgSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.msgSelect.Name = "msgSelect";
            this.msgSelect.Size = new System.Drawing.Size(282, 28);
            this.msgSelect.TabIndex = 3;
            this.msgSelect.SelectedIndexChanged += new System.EventHandler(this.msgSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Construct Message Manually";
            // 
            // messageLayout
            // 
            this.messageLayout.ColumnCount = 3;
            this.messageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.messageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.messageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.messageLayout.Location = new System.Drawing.Point(27, 174);
            this.messageLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.messageLayout.Size = new System.Drawing.Size(482, 702);
            this.messageLayout.TabIndex = 5;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(320, 117);
            this.sendMessageButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(176, 32);
            this.sendMessageButton.TabIndex = 6;
            this.sendMessageButton.Text = "Send Message";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.SystemColors.Info;
            this.infoBox.Location = new System.Drawing.Point(572, 9);
            this.infoBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoBox.Size = new System.Drawing.Size(740, 800);
            this.infoBox.TabIndex = 7;
            // 
            // clearInfoBox
            // 
            this.clearInfoBox.Location = new System.Drawing.Point(572, 840);
            this.clearInfoBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearInfoBox.Name = "clearInfoBox";
            this.clearInfoBox.Size = new System.Drawing.Size(742, 35);
            this.clearInfoBox.TabIndex = 8;
            this.clearInfoBox.Text = "Clear";
            this.clearInfoBox.UseVisualStyleBackColor = true;
            this.clearInfoBox.Click += new System.EventHandler(this.ClearInfoBox_Click);
            // 
            // altitudeBox
            // 
            this.altitudeBox.BackColor = System.Drawing.SystemColors.Control;
            this.altitudeBox.Location = new System.Drawing.Point(60, 146);
            this.altitudeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.altitudeBox.Name = "altitudeBox";
            this.altitudeBox.ReadOnly = true;
            this.altitudeBox.Size = new System.Drawing.Size(148, 26);
            this.altitudeBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Altitude";
            // 
            // rollBox
            // 
            this.rollBox.AutoSize = true;
            this.rollBox.Location = new System.Drawing.Point(117, 203);
            this.rollBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rollBox.Name = "rollBox";
            this.rollBox.Size = new System.Drawing.Size(36, 20);
            this.rollBox.TabIndex = 12;
            this.rollBox.Text = "Roll";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(60, 228);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(148, 26);
            this.textBox2.TabIndex = 11;
            // 
            // pitchBox
            // 
            this.pitchBox.AutoSize = true;
            this.pitchBox.Location = new System.Drawing.Point(117, 289);
            this.pitchBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pitchBox.Name = "pitchBox";
            this.pitchBox.Size = new System.Drawing.Size(44, 20);
            this.pitchBox.TabIndex = 14;
            this.pitchBox.Text = "Pitch";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(60, 314);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(148, 26);
            this.textBox3.TabIndex = 13;
            // 
            // yawBox
            // 
            this.yawBox.AutoSize = true;
            this.yawBox.Location = new System.Drawing.Point(117, 377);
            this.yawBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yawBox.Name = "yawBox";
            this.yawBox.Size = new System.Drawing.Size(40, 20);
            this.yawBox.TabIndex = 16;
            this.yawBox.Text = "Yaw";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(60, 402);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(148, 26);
            this.textBox4.TabIndex = 15;
            // 
            // flightInfo
            // 
            this.flightInfo.AutoSize = true;
            this.flightInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flightInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightInfo.Location = new System.Drawing.Point(34, 45);
            this.flightInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.flightInfo.Name = "flightInfo";
            this.flightInfo.Size = new System.Drawing.Size(231, 33);
            this.flightInfo.TabIndex = 18;
            this.flightInfo.Text = "Flight Infomation";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(3, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1340, 929);
            this.tabControl.TabIndex = 19;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1332, 896);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // armButton
            // 
            this.armButton.Enabled = false;
            this.armButton.Location = new System.Drawing.Point(434, 26);
            this.armButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.armButton.Name = "armButton";
            this.armButton.Size = new System.Drawing.Size(112, 35);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1332, 896);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flight State";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // InitWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 928);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InitWindow";
            this.Text = "NEST Mavlink Adapter";
            this.Load += new System.EventHandler(this.InitWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
    }
}

