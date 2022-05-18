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
            this.announcementSettingsGroup = new System.Windows.Forms.GroupBox();
            this.voiceSpeedLabel = new System.Windows.Forms.Label();
            this.speedSelector = new System.Windows.Forms.NumericUpDown();
            this.voiceLabel = new System.Windows.Forms.Label();
            this.voiceSelector = new System.Windows.Forms.ComboBox();
            this.testAnnouncementButton = new System.Windows.Forms.Button();
            this.speedUnitsLabel = new System.Windows.Forms.Label();
            this.speedUnitSelector = new System.Windows.Forms.ComboBox();
            this.sayTenthsCheckBox = new System.Windows.Forms.CheckBox();
            this.leftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dataLabel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.manageMarkersGroup.SuspendLayout();
            this.controlsSettingsGroup.SuspendLayout();
            this.announcementSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelector)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startStopButton
            // 
            this.startStopButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startStopButton.Location = new System.Drawing.Point(91, 16);
            this.startStopButton.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(194, 47);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 660);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip.Size = new System.Drawing.Size(792, 26);
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
            this.pointsListBox.Location = new System.Drawing.Point(2, 101);
            this.pointsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.pointsListBox.Name = "pointsListBox";
            this.pointsListBox.Size = new System.Drawing.Size(390, 404);
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
            this.addPositionButton.Click += new System.EventHandler(this.addPositionButton_Click);
            // 
            // gameControllersList
            // 
            this.gameControllersList.FormattingEnabled = true;
            this.gameControllersList.ItemHeight = 20;
            this.gameControllersList.Location = new System.Drawing.Point(11, 327);
            this.gameControllersList.Name = "gameControllersList";
            this.gameControllersList.Size = new System.Drawing.Size(355, 164);
            this.gameControllersList.TabIndex = 8;
            // 
            // controllersLabel
            // 
            this.controllersLabel.AutoSize = true;
            this.controllersLabel.Location = new System.Drawing.Point(11, 304);
            this.controllersLabel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 0);
            this.controllersLabel.Name = "controllersLabel";
            this.controllersLabel.Size = new System.Drawing.Size(157, 20);
            this.controllersLabel.TabIndex = 11;
            this.controllersLabel.Text = "Connected controllers:";
            // 
            // trackMarkersLabel
            // 
            this.trackMarkersLabel.AutoSize = true;
            this.trackMarkersLabel.Location = new System.Drawing.Point(3, 79);
            this.trackMarkersLabel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 0);
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
            this.manageMarkersGroup.Location = new System.Drawing.Point(3, 510);
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
            this.deleteMarkerButton.Click += new System.EventHandler(this.deleteMarkerButton_Click);
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
            this.labelM2.Name = "labelM2";
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
            this.addRegionButton.Text = "Add Section";
            this.addRegionButton.UseVisualStyleBackColor = true;
            this.addRegionButton.Click += new System.EventHandler(this.addRegionButton_Click);
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
            this.controlsSettingsGroup.Location = new System.Drawing.Point(11, 497);
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
            // announcementSettingsGroup
            // 
            this.announcementSettingsGroup.Controls.Add(this.voiceSpeedLabel);
            this.announcementSettingsGroup.Controls.Add(this.speedSelector);
            this.announcementSettingsGroup.Controls.Add(this.voiceLabel);
            this.announcementSettingsGroup.Controls.Add(this.voiceSelector);
            this.announcementSettingsGroup.Controls.Add(this.testAnnouncementButton);
            this.announcementSettingsGroup.Controls.Add(this.speedUnitsLabel);
            this.announcementSettingsGroup.Controls.Add(this.speedUnitSelector);
            this.announcementSettingsGroup.Controls.Add(this.sayTenthsCheckBox);
            this.announcementSettingsGroup.Location = new System.Drawing.Point(11, 79);
            this.announcementSettingsGroup.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.announcementSettingsGroup.Name = "announcementSettingsGroup";
            this.announcementSettingsGroup.Padding = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.announcementSettingsGroup.Size = new System.Drawing.Size(355, 206);
            this.announcementSettingsGroup.TabIndex = 16;
            this.announcementSettingsGroup.TabStop = false;
            this.announcementSettingsGroup.Text = "Announcement settings";
            // 
            // voiceSpeedLabel
            // 
            this.voiceSpeedLabel.AutoSize = true;
            this.voiceSpeedLabel.Location = new System.Drawing.Point(10, 117);
            this.voiceSpeedLabel.Name = "voiceSpeedLabel";
            this.voiceSpeedLabel.Size = new System.Drawing.Size(54, 20);
            this.voiceSpeedLabel.TabIndex = 7;
            this.voiceSpeedLabel.Text = "Speed:";
            // 
            // speedSelector
            // 
            this.speedSelector.Location = new System.Drawing.Point(109, 102);
            this.speedSelector.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.speedSelector.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.speedSelector.Name = "speedSelector";
            this.speedSelector.Size = new System.Drawing.Size(63, 27);
            this.speedSelector.TabIndex = 6;
            this.speedSelector.ValueChanged += new System.EventHandler(this.speedSelector_ValueChanged);
            // 
            // voiceLabel
            // 
            this.voiceLabel.AutoSize = true;
            this.voiceLabel.Location = new System.Drawing.Point(10, 78);
            this.voiceLabel.Name = "voiceLabel";
            this.voiceLabel.Size = new System.Drawing.Size(48, 20);
            this.voiceLabel.TabIndex = 5;
            this.voiceLabel.Text = "Voice:";
            // 
            // voiceSelector
            // 
            this.voiceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voiceSelector.FormattingEnabled = true;
            this.voiceSelector.Location = new System.Drawing.Point(105, 62);
            this.voiceSelector.Name = "voiceSelector";
            this.voiceSelector.Size = new System.Drawing.Size(232, 28);
            this.voiceSelector.TabIndex = 4;
            // 
            // testAnnouncementButton
            // 
            this.testAnnouncementButton.Location = new System.Drawing.Point(105, 171);
            this.testAnnouncementButton.Name = "testAnnouncementButton";
            this.testAnnouncementButton.Size = new System.Drawing.Size(103, 29);
            this.testAnnouncementButton.TabIndex = 3;
            this.testAnnouncementButton.Text = "Test";
            this.testAnnouncementButton.UseVisualStyleBackColor = true;
            this.testAnnouncementButton.Click += new System.EventHandler(this.testAnnouncementButton_Click);
            // 
            // speedUnitsLabel
            // 
            this.speedUnitsLabel.AutoSize = true;
            this.speedUnitsLabel.Location = new System.Drawing.Point(10, 39);
            this.speedUnitsLabel.Name = "speedUnitsLabel";
            this.speedUnitsLabel.Size = new System.Drawing.Size(89, 20);
            this.speedUnitsLabel.TabIndex = 2;
            this.speedUnitsLabel.Text = "Speed units:";
            // 
            // speedUnitSelector
            // 
            this.speedUnitSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedUnitSelector.FormattingEnabled = true;
            this.speedUnitSelector.Items.AddRange(new object[] {
            "km/h",
            "MPH"});
            this.speedUnitSelector.Location = new System.Drawing.Point(105, 24);
            this.speedUnitSelector.Name = "speedUnitSelector";
            this.speedUnitSelector.Size = new System.Drawing.Size(93, 28);
            this.speedUnitSelector.TabIndex = 1;
            this.speedUnitSelector.SelectedIndexChanged += new System.EventHandler(this.speedUnitSelector_SelectedIndexChanged);
            // 
            // sayTenthsCheckBox
            // 
            this.sayTenthsCheckBox.AutoSize = true;
            this.sayTenthsCheckBox.Location = new System.Drawing.Point(204, 39);
            this.sayTenthsCheckBox.Name = "sayTenthsCheckBox";
            this.sayTenthsCheckBox.Size = new System.Drawing.Size(98, 24);
            this.sayTenthsCheckBox.TabIndex = 0;
            this.sayTenthsCheckBox.Text = "Say tenths";
            this.sayTenthsCheckBox.UseVisualStyleBackColor = true;
            this.sayTenthsCheckBox.CheckedChanged += new System.EventHandler(this.sayTenthsCheckBox_CheckedChanged);
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.startStopButton);
            this.leftPanel.Controls.Add(this.announcementSettingsGroup);
            this.leftPanel.Controls.Add(this.controllersLabel);
            this.leftPanel.Controls.Add(this.gameControllersList);
            this.leftPanel.Controls.Add(this.controlsSettingsGroup);
            this.leftPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.leftPanel.Location = new System.Drawing.Point(0, -1);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(8);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Padding = new System.Windows.Forms.Padding(8);
            this.leftPanel.Size = new System.Drawing.Size(375, 658);
            this.leftPanel.TabIndex = 17;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.dataLabel);
            this.rightPanel.Controls.Add(this.trackMarkersLabel);
            this.rightPanel.Controls.Add(this.pointsListBox);
            this.rightPanel.Controls.Add(this.manageMarkersGroup);
            this.rightPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.rightPanel.Location = new System.Drawing.Point(381, -1);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(411, 658);
            this.rightPanel.TabIndex = 18;
            // 
            // dataLabel
            // 
            this.dataLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLabel.AutoSize = true;
            this.dataLabel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataLabel.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dataLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataLabel.Location = new System.Drawing.Point(8, 20);
            this.dataLabel.Margin = new System.Windows.Forms.Padding(8, 20, 8, 8);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Padding = new System.Windows.Forms.Padding(4);
            this.dataLabel.Size = new System.Drawing.Size(378, 35);
            this.dataLabel.TabIndex = 15;
            this.dataLabel.Text = "166 MPH    1456.4 - 1689.7";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 686);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.statusStrip);
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
            this.announcementSettingsGroup.ResumeLayout(false);
            this.announcementSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelector)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startStopButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ListBox pointsListBox;
        private Button addPositionButton;
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
        private GroupBox announcementSettingsGroup;
        private Button testAnnouncementButton;
        private Label speedUnitsLabel;
        private ComboBox speedUnitSelector;
        private CheckBox sayTenthsCheckBox;
        private ComboBox voiceSelector;
        private Label voiceLabel;
        private Label voiceSpeedLabel;
        private NumericUpDown speedSelector;
        private FlowLayoutPanel leftPanel;
        private FlowLayoutPanel rightPanel;
        private Label dataLabel;
    }
}