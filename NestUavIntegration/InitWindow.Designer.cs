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
            this.typeSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.messageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "14550";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listening Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // typeSelect
            // 
            this.typeSelect.FormattingEnabled = true;
            this.typeSelect.Location = new System.Drawing.Point(16, 72);
            this.typeSelect.Name = "typeSelect";
            this.typeSelect.Size = new System.Drawing.Size(189, 21);
            this.typeSelect.TabIndex = 3;
            this.typeSelect.SelectedIndexChanged += new System.EventHandler(this.typeSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
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
            this.messageLayout.Location = new System.Drawing.Point(16, 109);
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
            this.messageLayout.Size = new System.Drawing.Size(546, 294);
            this.messageLayout.TabIndex = 5;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(212, 69);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(117, 23);
            this.sendMessageButton.TabIndex = 6;
            this.sendMessageButton.Text = "Send Message";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // InitWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 415);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.messageLayout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeSelect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "InitWindow";
            this.Text = "NEST Mavlink Adapter";
            this.Load += new System.EventHandler(this.InitWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox typeSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel messageLayout;
        private System.Windows.Forms.Button sendMessageButton;
    }
}

