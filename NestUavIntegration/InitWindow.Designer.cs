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
            this.portTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mavConnect = new System.Windows.Forms.Button();
            this.msgSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.messageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.clearInfoBox = new System.Windows.Forms.Button();
            this.altitudeTb = new System.Windows.Forms.TextBox();
            this.altitudeLabel = new System.Windows.Forms.Label();
            this.rollLabel = new System.Windows.Forms.Label();
            this.rollTb = new System.Windows.Forms.TextBox();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.pitchTb = new System.Windows.Forms.TextBox();
            this.yawLabel = new System.Windows.Forms.Label();
            this.yawTb = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.waypointBtn = new System.Windows.Forms.Button();
            this.armedLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.vehicleMode = new System.Windows.Forms.Label();
            this.mavStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.armButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pitchSpdTb = new System.Windows.Forms.TextBox();
            this.yawSpdLabel = new System.Windows.Forms.Label();
            this.rollSpdLabel = new System.Windows.Forms.Label();
            this.pitchSpdLabel = new System.Windows.Forms.Label();
            this.yawSpdTb = new System.Windows.Forms.TextBox();
            this.rollSpdTb = new System.Windows.Forms.TextBox();
            this.speedDataLabel = new System.Windows.Forms.Label();
            this.imuLabel = new System.Windows.Forms.Label();
            this.imuPanel = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.testButton = new System.Windows.Forms.Button();
            this.nestUrlTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nestConnect = new System.Windows.Forms.Button();
            this.startMissionBtn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.imuPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(92, 19);
            this.portTb.Name = "portTb";
            this.portTb.Size = new System.Drawing.Size(100, 20);
            this.portTb.TabIndex = 0;
            this.portTb.Text = "14550";
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
            // mavConnect
            // 
            this.mavConnect.Location = new System.Drawing.Point(207, 17);
            this.mavConnect.Name = "mavConnect";
            this.mavConnect.Size = new System.Drawing.Size(75, 23);
            this.mavConnect.TabIndex = 2;
            this.mavConnect.Text = "Connect";
            this.mavConnect.UseVisualStyleBackColor = true;
            this.mavConnect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // msgSelect
            // 
            this.msgSelect.FormattingEnabled = true;
            this.msgSelect.Location = new System.Drawing.Point(18, 448);
            this.msgSelect.Name = "msgSelect";
            this.msgSelect.Size = new System.Drawing.Size(198, 21);
            this.msgSelect.TabIndex = 3;
            this.msgSelect.SelectedIndexChanged += new System.EventHandler(this.msgSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 432);
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
            this.sendMessageButton.Location = new System.Drawing.Point(222, 447);
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
            // altitudeTb
            // 
            this.altitudeTb.BackColor = System.Drawing.Color.Chocolate;
            this.altitudeTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.altitudeTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altitudeTb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.altitudeTb.Location = new System.Drawing.Point(89, 23);
            this.altitudeTb.Name = "altitudeTb";
            this.altitudeTb.ReadOnly = true;
            this.altitudeTb.Size = new System.Drawing.Size(100, 28);
            this.altitudeTb.TabIndex = 9;
            this.altitudeTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // altitudeLabel
            // 
            this.altitudeLabel.AutoSize = true;
            this.altitudeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altitudeLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.altitudeLabel.Location = new System.Drawing.Point(35, 23);
            this.altitudeLabel.Name = "altitudeLabel";
            this.altitudeLabel.Size = new System.Drawing.Size(40, 25);
            this.altitudeLabel.TabIndex = 10;
            this.altitudeLabel.Text = "Alt";
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollLabel.ForeColor = System.Drawing.Color.Violet;
            this.rollLabel.Location = new System.Drawing.Point(26, 73);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(53, 25);
            this.rollLabel.TabIndex = 12;
            this.rollLabel.Text = "Roll";
            // 
            // rollTb
            // 
            this.rollTb.BackColor = System.Drawing.Color.Purple;
            this.rollTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rollTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollTb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rollTb.Location = new System.Drawing.Point(89, 73);
            this.rollTb.Name = "rollTb";
            this.rollTb.ReadOnly = true;
            this.rollTb.Size = new System.Drawing.Size(100, 28);
            this.rollTb.TabIndex = 11;
            this.rollTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pitchLabel
            // 
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitchLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.pitchLabel.Location = new System.Drawing.Point(14, 123);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(65, 25);
            this.pitchLabel.TabIndex = 14;
            this.pitchLabel.Text = "Pitch";
            // 
            // pitchTb
            // 
            this.pitchTb.BackColor = System.Drawing.Color.SteelBlue;
            this.pitchTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pitchTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitchTb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.pitchTb.Location = new System.Drawing.Point(89, 123);
            this.pitchTb.Name = "pitchTb";
            this.pitchTb.ReadOnly = true;
            this.pitchTb.Size = new System.Drawing.Size(100, 28);
            this.pitchTb.TabIndex = 13;
            this.pitchTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yawLabel
            // 
            this.yawLabel.AutoSize = true;
            this.yawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yawLabel.ForeColor = System.Drawing.Color.Gold;
            this.yawLabel.Location = new System.Drawing.Point(18, 175);
            this.yawLabel.Name = "yawLabel";
            this.yawLabel.Size = new System.Drawing.Size(57, 25);
            this.yawLabel.TabIndex = 16;
            this.yawLabel.Text = "Yaw";
            // 
            // yawTb
            // 
            this.yawTb.BackColor = System.Drawing.Color.Goldenrod;
            this.yawTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yawTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yawTb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.yawTb.Location = new System.Drawing.Point(89, 175);
            this.yawTb.Name = "yawTb";
            this.yawTb.ReadOnly = true;
            this.yawTb.Size = new System.Drawing.Size(100, 28);
            this.yawTb.TabIndex = 15;
            this.yawTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.tabPage1.Controls.Add(this.startMissionBtn);
            this.tabPage1.Controls.Add(this.waypointBtn);
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
            this.tabPage1.Controls.Add(this.portTb);
            this.tabPage1.Controls.Add(this.messageLayout);
            this.tabPage1.Controls.Add(this.mavConnect);
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
            // waypointBtn
            // 
            this.waypointBtn.Location = new System.Drawing.Point(207, 51);
            this.waypointBtn.Name = "waypointBtn";
            this.waypointBtn.Size = new System.Drawing.Size(75, 39);
            this.waypointBtn.TabIndex = 20;
            this.waypointBtn.Text = "Load Waypoints";
            this.waypointBtn.UseVisualStyleBackColor = true;
            this.waypointBtn.Click += new System.EventHandler(this.waypointBtn_Click);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Armed:";
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
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.speedDataLabel);
            this.tabPage2.Controls.Add(this.imuLabel);
            this.tabPage2.Controls.Add(this.imuPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 578);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Flight State";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.pitchSpdTb);
            this.panel1.Controls.Add(this.yawSpdLabel);
            this.panel1.Controls.Add(this.rollSpdLabel);
            this.panel1.Controls.Add(this.pitchSpdLabel);
            this.panel1.Controls.Add(this.yawSpdTb);
            this.panel1.Controls.Add(this.rollSpdTb);
            this.panel1.Location = new System.Drawing.Point(261, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 229);
            this.panel1.TabIndex = 20;
            // 
            // pitchSpdTb
            // 
            this.pitchSpdTb.BackColor = System.Drawing.Color.DarkSalmon;
            this.pitchSpdTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pitchSpdTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitchSpdTb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.pitchSpdTb.Location = new System.Drawing.Point(158, 73);
            this.pitchSpdTb.Name = "pitchSpdTb";
            this.pitchSpdTb.ReadOnly = true;
            this.pitchSpdTb.Size = new System.Drawing.Size(100, 28);
            this.pitchSpdTb.TabIndex = 13;
            this.pitchSpdTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // yawSpdLabel
            // 
            this.yawSpdLabel.AutoSize = true;
            this.yawSpdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yawSpdLabel.ForeColor = System.Drawing.Color.GreenYellow;
            this.yawSpdLabel.Location = new System.Drawing.Point(21, 123);
            this.yawSpdLabel.Name = "yawSpdLabel";
            this.yawSpdLabel.Size = new System.Drawing.Size(131, 25);
            this.yawSpdLabel.TabIndex = 16;
            this.yawSpdLabel.Text = "Yaw Speed";
            // 
            // rollSpdLabel
            // 
            this.rollSpdLabel.AutoSize = true;
            this.rollSpdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollSpdLabel.ForeColor = System.Drawing.Color.PowderBlue;
            this.rollSpdLabel.Location = new System.Drawing.Point(25, 23);
            this.rollSpdLabel.Name = "rollSpdLabel";
            this.rollSpdLabel.Size = new System.Drawing.Size(127, 25);
            this.rollSpdLabel.TabIndex = 12;
            this.rollSpdLabel.Text = "Roll Speed";
            // 
            // pitchSpdLabel
            // 
            this.pitchSpdLabel.AutoSize = true;
            this.pitchSpdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitchSpdLabel.ForeColor = System.Drawing.Color.Salmon;
            this.pitchSpdLabel.Location = new System.Drawing.Point(13, 73);
            this.pitchSpdLabel.Name = "pitchSpdLabel";
            this.pitchSpdLabel.Size = new System.Drawing.Size(139, 25);
            this.pitchSpdLabel.TabIndex = 14;
            this.pitchSpdLabel.Text = "Pitch Speed";
            // 
            // yawSpdTb
            // 
            this.yawSpdTb.BackColor = System.Drawing.Color.OliveDrab;
            this.yawSpdTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yawSpdTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yawSpdTb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.yawSpdTb.Location = new System.Drawing.Point(158, 125);
            this.yawSpdTb.Name = "yawSpdTb";
            this.yawSpdTb.ReadOnly = true;
            this.yawSpdTb.Size = new System.Drawing.Size(100, 28);
            this.yawSpdTb.TabIndex = 15;
            this.yawSpdTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rollSpdTb
            // 
            this.rollSpdTb.BackColor = System.Drawing.Color.Teal;
            this.rollSpdTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rollSpdTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollSpdTb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rollSpdTb.Location = new System.Drawing.Point(158, 23);
            this.rollSpdTb.Name = "rollSpdTb";
            this.rollSpdTb.ReadOnly = true;
            this.rollSpdTb.Size = new System.Drawing.Size(100, 28);
            this.rollSpdTb.TabIndex = 11;
            this.rollSpdTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // speedDataLabel
            // 
            this.speedDataLabel.AutoSize = true;
            this.speedDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedDataLabel.Location = new System.Drawing.Point(332, 12);
            this.speedDataLabel.Name = "speedDataLabel";
            this.speedDataLabel.Size = new System.Drawing.Size(157, 31);
            this.speedDataLabel.TabIndex = 19;
            this.speedDataLabel.Text = "Speed Data";
            // 
            // imuLabel
            // 
            this.imuLabel.AutoSize = true;
            this.imuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imuLabel.Location = new System.Drawing.Point(61, 12);
            this.imuLabel.Name = "imuLabel";
            this.imuLabel.Size = new System.Drawing.Size(129, 31);
            this.imuLabel.TabIndex = 18;
            this.imuLabel.Text = "IMU Data";
            // 
            // imuPanel
            // 
            this.imuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.imuPanel.Controls.Add(this.altitudeLabel);
            this.imuPanel.Controls.Add(this.altitudeTb);
            this.imuPanel.Controls.Add(this.pitchTb);
            this.imuPanel.Controls.Add(this.yawLabel);
            this.imuPanel.Controls.Add(this.rollLabel);
            this.imuPanel.Controls.Add(this.pitchLabel);
            this.imuPanel.Controls.Add(this.yawTb);
            this.imuPanel.Controls.Add(this.rollTb);
            this.imuPanel.Location = new System.Drawing.Point(17, 46);
            this.imuPanel.Name = "imuPanel";
            this.imuPanel.Size = new System.Drawing.Size(215, 229);
            this.imuPanel.TabIndex = 17;
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
            // startMissionBtn
            // 
            this.startMissionBtn.Location = new System.Drawing.Point(289, 51);
            this.startMissionBtn.Name = "startMissionBtn";
            this.startMissionBtn.Size = new System.Drawing.Size(75, 39);
            this.startMissionBtn.TabIndex = 21;
            this.startMissionBtn.Text = "Start Mission";
            this.startMissionBtn.UseVisualStyleBackColor = true;
            this.startMissionBtn.Click += new System.EventHandler(this.startMissionBtn_Click);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.imuPanel.ResumeLayout(false);
            this.imuPanel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox portTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mavConnect;
        private System.Windows.Forms.ComboBox msgSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel messageLayout;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Button clearInfoBox;
        private System.Windows.Forms.TextBox altitudeTb;
        private System.Windows.Forms.Label altitudeLabel;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.TextBox rollTb;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.TextBox pitchTb;
        private System.Windows.Forms.Label yawLabel;
        private System.Windows.Forms.TextBox yawTb;
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
        private System.Windows.Forms.Panel imuPanel;
        private System.Windows.Forms.Label imuLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox pitchSpdTb;
        private System.Windows.Forms.Label yawSpdLabel;
        private System.Windows.Forms.Label rollSpdLabel;
        private System.Windows.Forms.Label pitchSpdLabel;
        private System.Windows.Forms.TextBox yawSpdTb;
        private System.Windows.Forms.TextBox rollSpdTb;
        private System.Windows.Forms.Label speedDataLabel;
        private System.Windows.Forms.Button waypointBtn;
        private System.Windows.Forms.Button startMissionBtn;
    }
}

