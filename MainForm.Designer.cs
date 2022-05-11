namespace IRacingSpeedTrainer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startStopButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDataLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pointsListBox = new System.Windows.Forms.ListBox();
            this.addPosButton = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(12, 12);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(167, 59);
            this.startStopButton.TabIndex = 0;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripDataLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 418);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 32);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(169, 25);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // toolStripDataLabel
            // 
            this.toolStripDataLabel.Name = "toolStripDataLabel";
            this.toolStripDataLabel.Size = new System.Drawing.Size(616, 25);
            this.toolStripDataLabel.Spring = true;
            this.toolStripDataLabel.Text = "toolStripDataLabel";
            // 
            // pointsListBox
            // 
            this.pointsListBox.FormattingEnabled = true;
            this.pointsListBox.ItemHeight = 25;
            this.pointsListBox.Location = new System.Drawing.Point(358, 12);
            this.pointsListBox.Name = "pointsListBox";
            this.pointsListBox.Size = new System.Drawing.Size(320, 229);
            this.pointsListBox.TabIndex = 2;
            // 
            // addPosButton
            // 
            this.addPosButton.Location = new System.Drawing.Point(358, 267);
            this.addPosButton.Name = "addPosButton";
            this.addPosButton.Size = new System.Drawing.Size(155, 34);
            this.addPosButton.TabIndex = 3;
            this.addPosButton.Text = "Add Position";
            this.addPosButton.UseVisualStyleBackColor = true;
            this.addPosButton.Click += new System.EventHandler(this.addPosButton_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.speedLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.speedLabel.Location = new System.Drawing.Point(410, 332);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(105, 45);
            this.speedLabel.TabIndex = 4;
            this.speedLabel.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(611, 307);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "134.4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.addPosButton);
            this.Controls.Add(this.pointsListBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.startStopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "iRacing Speed Trainer";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startStopButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel toolStripDataLabel;
        private ListBox pointsListBox;
        private Button addPosButton;
        private Label speedLabel;
        private TextBox textBox1;
        private Button button1;
    }
}