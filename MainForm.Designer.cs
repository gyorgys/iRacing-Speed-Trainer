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
            this.pointsListBox = new System.Windows.Forms.ListBox();
            this.addPositionButton = new System.Windows.Forms.Button();
            this.dataLabel = new System.Windows.Forms.Label();
            this.gameControllersList = new System.Windows.Forms.ListBox();
            this.controllersLabel = new System.Windows.Forms.Label();
            this.trackMarkersLabel = new System.Windows.Forms.Label();
            this.pointDistanceTextBox = new System.Windows.Forms.TextBox();
            this.manageMarkersGroup = new System.Windows.Forms.GroupBox();
            this.deleteMarkerButton = new System.Windows.Forms.Button();
            this.regionEndDistanceTextBox = new System.Windows.Forms.TextBox();
            this.labelM2 = new System.Windows.Forms.Label();
            this.regionStartDistanceTextBox = new System.Windows.Forms.TextBox();
            this.addRegionButton = new System.Windows.Forms.Button();
            this.labelM1 = new System.Windows.Forms.Label();
            this.controlsSettingsGroup = new System.Windows.Forms.GroupBox();
            this.setPointControlButton = new System.Windows.Forms.Button();
            this.pointControlTextBox = new System.Windows.Forms.TextBox();
            this.setPointControlLabel = new System.Windows.Forms.Label();
            this.doubleClickPointSetCheckBox = new System.Windows.Forms.CheckBox();
            this.setRegionControlButton = new System.Windows.Forms.Button();
            this.regionControlTextBox = new System.Windows.Forms.TextBox();
            this.regionControlLabel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.manageMarkersGroup.SuspendLayout();
            this.controlsSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(10, 10);
            this.startStopButton.Margin = new System.Windows.Forms.Padding(2);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(134, 47);
            this.startStopButton.TabIndex = 0;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 807);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip.Size = new System.Drawing.Size(1203, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(143, 20);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pointsListBox
            // 
            this.pointsListBox.FormattingEnabled = true;
            this.pointsListBox.ItemHeight = 20;
            this.pointsListBox.Location = new System.Drawing.Point(381, 39);
            this.pointsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.pointsListBox.Name = "pointsListBox";
            this.pointsListBox.Size = new System.Drawing.Size(390, 384);
            this.pointsListBox.TabIndex = 2;
            this.pointsListBox.SelectedIndexChanged += new System.EventHandler(this.pointsListBox_SelectedIndexChanged);
            // 
            // addPositionButton
            // 
            this.addPositionButton.Location = new System.Drawing.Point(5, 26);
            this.addPositionButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPositionButton.Name = "addPositionButton";
            this.addPositionButton.Size = new System.Drawing.Size(116, 27);
            this.addPositionButton.TabIndex = 3;
            this.addPositionButton.Text = "Add Point";
            this.addPositionButton.UseVisualStyleBackColor = true;
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(443, 725);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(50, 20);
            this.dataLabel.TabIndex = 7;
            this.dataLabel.Text = "label1";
            // 
            // gameControllersList
            // 
            this.gameControllersList.FormattingEnabled = true;
            this.gameControllersList.ItemHeight = 20;
            this.gameControllersList.Location = new System.Drawing.Point(10, 109);
            this.gameControllersList.Name = "gameControllersList";
            this.gameControllersList.Size = new System.Drawing.Size(355, 164);
            this.gameControllersList.TabIndex = 8;
            // 
            // controllersLabel
            // 
            this.controllersLabel.AutoSize = true;
            this.controllersLabel.Location = new System.Drawing.Point(10, 86);
            this.controllersLabel.Name = "controllersLabel";
            this.controllersLabel.Size = new System.Drawing.Size(157, 20);
            this.controllersLabel.TabIndex = 11;
            this.controllersLabel.Text = "Connected controllers:";
            // 
            // labelTrackMarkers
            // 
            this.trackMarkersLabel.AutoSize = true;
            this.trackMarkersLabel.Location = new System.Drawing.Point(381, 16);
            this.trackMarkersLabel.Name = "trackMarkersLabel";
            this.trackMarkersLabel.Size = new System.Drawing.Size(102, 20);
            this.trackMarkersLabel.TabIndex = 12;
            this.trackMarkersLabel.Text = "Track Markers:";
            // 
            // pointDistanceTextBox
            // 
            this.pointDistanceTextBox.Location = new System.Drawing.Point(126, 26);
            this.pointDistanceTextBox.Name = "pointDistanceTextBox";
            this.pointDistanceTextBox.Size = new System.Drawing.Size(82, 27);
            this.pointDistanceTextBox.TabIndex = 13;
            // 
            // manageMarkersGroup
            // 
            this.manageMarkersGroup.Controls.Add(this.deleteMarkerButton);
            this.manageMarkersGroup.Controls.Add(this.regionEndDistanceTextBox);
            this.manageMarkersGroup.Controls.Add(this.labelM2);
            this.manageMarkersGroup.Controls.Add(this.regionStartDistanceTextBox);
            this.manageMarkersGroup.Controls.Add(this.addRegionButton);
            this.manageMarkersGroup.Controls.Add(this.labelM1);
            this.manageMarkersGroup.Controls.Add(this.pointDistanceTextBox);
            this.manageMarkersGroup.Controls.Add(this.addPositionButton);
            this.manageMarkersGroup.Location = new System.Drawing.Point(786, 39);
            this.manageMarkersGroup.Name = "manageMarkersGroup";
            this.manageMarkersGroup.Size = new System.Drawing.Size(329, 134);
            this.manageMarkersGroup.TabIndex = 14;
            this.manageMarkersGroup.TabStop = false;
            this.manageMarkersGroup.Text = "Manage markers";
            // 
            // deleteMarkerButton
            // 
            this.deleteMarkerButton.Location = new System.Drawing.Point(5, 90);
            this.deleteMarkerButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteMarkerButton.Name = "deleteMarkerButton";
            this.deleteMarkerButton.Size = new System.Drawing.Size(116, 27);
            this.deleteMarkerButton.TabIndex = 19;
            this.deleteMarkerButton.Text = "Delete";
            this.deleteMarkerButton.UseVisualStyleBackColor = true;
            // 
            // regionEndDistanceTextBox
            // 
            this.regionEndDistanceTextBox.Location = new System.Drawing.Point(214, 59);
            this.regionEndDistanceTextBox.Name = "regionEndDistanceTextBox";
            this.regionEndDistanceTextBox.Size = new System.Drawing.Size(82, 27);
            this.regionEndDistanceTextBox.TabIndex = 18;
            // 
            // labelM2
            // 
            this.labelM2.AutoSize = true;
            this.labelM2.Location = new System.Drawing.Point(299, 62);
            this.labelM2.Name = "label1M2";
            this.labelM2.Size = new System.Drawing.Size(22, 20);
            this.labelM2.TabIndex = 17;
            this.labelM2.Text = "m";
            // 
            // regionStartDistanceTextBox
            // 
            this.regionStartDistanceTextBox.Location = new System.Drawing.Point(126, 59);
            this.regionStartDistanceTextBox.Name = "regionStartDistanceTextBox";
            this.regionStartDistanceTextBox.Size = new System.Drawing.Size(82, 27);
            this.regionStartDistanceTextBox.TabIndex = 16;
            // 
            // addRegionButton
            // 
            this.addRegionButton.Location = new System.Drawing.Point(5, 59);
            this.addRegionButton.Margin = new System.Windows.Forms.Padding(2);
            this.addRegionButton.Name = "addRegionButton";
            this.addRegionButton.Size = new System.Drawing.Size(116, 27);
            this.addRegionButton.TabIndex = 15;
            this.addRegionButton.Text = "Add Region";
            this.addRegionButton.UseVisualStyleBackColor = true;
            // 
            // labelM1
            // 
            this.labelM1.AutoSize = true;
            this.labelM1.Location = new System.Drawing.Point(214, 29);
            this.labelM1.Name = "labelM1";
            this.labelM1.Size = new System.Drawing.Size(22, 20);
            this.labelM1.TabIndex = 14;
            this.labelM1.Text = "m";
            // 
            // controlsSettingsGroup
            // 
            this.controlsSettingsGroup.Controls.Add(this.setPointControlButton);
            this.controlsSettingsGroup.Controls.Add(this.pointControlTextBox);
            this.controlsSettingsGroup.Controls.Add(this.setPointControlLabel);
            this.controlsSettingsGroup.Controls.Add(this.doubleClickPointSetCheckBox);
            this.controlsSettingsGroup.Controls.Add(this.setRegionControlButton);
            this.controlsSettingsGroup.Controls.Add(this.regionControlTextBox);
            this.controlsSettingsGroup.Controls.Add(this.regionControlLabel);
            this.controlsSettingsGroup.Location = new System.Drawing.Point(10, 291);
            this.controlsSettingsGroup.Name = "controlsSettingsGroup";
            this.controlsSettingsGroup.Size = new System.Drawing.Size(355, 127);
            this.controlsSettingsGroup.TabIndex = 15;
            this.controlsSettingsGroup.TabStop = false;
            this.controlsSettingsGroup.Text = "Controls:";
            // 
            // setPointControlButton
            // 
            this.setPointControlButton.Location = new System.Drawing.Point(278, 84);
            this.setPointControlButton.Name = "setPointControlButton";
            this.setPointControlButton.Size = new System.Drawing.Size(71, 31);
            this.setPointControlButton.TabIndex = 6;
            this.setPointControlButton.Text = "Change";
            this.setPointControlButton.UseVisualStyleBackColor = true;
            this.setPointControlButton.Click += new System.EventHandler(this.setPointControlButton_Click);
            // 
            // pointControlTextBox
            // 
            this.pointControlTextBox.Location = new System.Drawing.Point(140, 84);
            this.pointControlTextBox.Name = "pointControlTextBox";
            this.pointControlTextBox.ReadOnly = true;
            this.pointControlTextBox.Size = new System.Drawing.Size(132, 27);
            this.pointControlTextBox.TabIndex = 5;
            // 
            // setPointControlLabel
            // 
            this.setPointControlLabel.AutoSize = true;
            this.setPointControlLabel.Location = new System.Drawing.Point(6, 86);
            this.setPointControlLabel.Name = "setPointControlLabel";
            this.setPointControlLabel.Size = new System.Drawing.Size(72, 20);
            this.setPointControlLabel.TabIndex = 4;
            this.setPointControlLabel.Text = "Set point:";
            // 
            // doubleClickPointSetCheckBox
            // 
            this.doubleClickPointSetCheckBox.AutoSize = true;
            this.doubleClickPointSetCheckBox.Checked = true;
            this.doubleClickPointSetCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doubleClickPointSetCheckBox.Location = new System.Drawing.Point(15, 58);
            this.doubleClickPointSetCheckBox.Name = "doubleClickPointSetCheckBox";
            this.doubleClickPointSetCheckBox.Size = new System.Drawing.Size(320, 24);
            this.doubleClickPointSetCheckBox.TabIndex = 3;
            this.doubleClickPointSetCheckBox.Text = "Double click region button for point marker";
            this.doubleClickPointSetCheckBox.UseVisualStyleBackColor = true;
            this.doubleClickPointSetCheckBox.CheckedChanged += new System.EventHandler(this.doubleClickPointSetCheckBox_CheckedChanged);
            // 
            // setRegionControlButton
            // 
            this.setRegionControlButton.Location = new System.Drawing.Point(278, 21);
            this.setRegionControlButton.Name = "setRegionControlButton";
            this.setRegionControlButton.Size = new System.Drawing.Size(71, 31);
            this.setRegionControlButton.TabIndex = 2;
            this.setRegionControlButton.Text = "Change";
            this.setRegionControlButton.UseVisualStyleBackColor = true;
            this.setRegionControlButton.Click += new System.EventHandler(this.setRegionControlButton_Click);
            // 
            // regionControlTextBox
            // 
            this.regionControlTextBox.Location = new System.Drawing.Point(140, 21);
            this.regionControlTextBox.Name = "regionControlTextBox";
            this.regionControlTextBox.ReadOnly = true;
            this.regionControlTextBox.Size = new System.Drawing.Size(132, 27);
            this.regionControlTextBox.TabIndex = 1;
            // 
            // regionControlLabel
            // 
            this.regionControlLabel.AutoSize = true;
            this.regionControlLabel.Location = new System.Drawing.Point(6, 23);
            this.regionControlLabel.Name = "regionControlLabel";
            this.regionControlLabel.Size = new System.Drawing.Size(129, 20);
            this.regionControlLabel.TabIndex = 0;
            this.regionControlLabel.Text = "Start / end region:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 833);
            this.Controls.Add(this.controlsSettingsGroup);
            this.Controls.Add(this.manageMarkersGroup);
            this.Controls.Add(this.trackMarkersLabel);
            this.Controls.Add(this.controllersLabel);
            this.Controls.Add(this.gameControllersList);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.pointsListBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.startStopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "iRacing Speed Trainer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.manageMarkersGroup.ResumeLayout(false);
            this.manageMarkersGroup.PerformLayout();
            this.controlsSettingsGroup.ResumeLayout(false);
            this.controlsSettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startStopButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ListBox pointsListBox;
        private Button addPositionButton;
        private Label dataLabel;
        private ListBox gameControllersList;
        private Label controllersLabel;
        private Label trackMarkersLabel;
        private TextBox pointDistanceTextBox;
        private GroupBox manageMarkersGroup;
        private Button deleteMarkerButton;
        private TextBox regionEndDistanceTextBox;
        private Label labelM2;
        private TextBox regionStartDistanceTextBox;
        private Button addRegionButton;
        private Label labelM1;
        private GroupBox controlsSettingsGroup;
        private Button setPointControlButton;
        private TextBox pointControlTextBox;
        private Label setPointControlLabel;
        private CheckBox doubleClickPointSetCheckBox;
        private Button setRegionControlButton;
        private TextBox regionControlTextBox;
        private Label regionControlLabel;
    }
}