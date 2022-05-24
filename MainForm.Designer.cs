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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.startStopButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.markersList = new System.Windows.Forms.CheckedListBox();
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
            this.enableMarkerRecordingCheckBox = new System.Windows.Forms.CheckBox();
            this.setPointControlButton = new System.Windows.Forms.Button();
            this.pointControlSettingLabel = new System.Windows.Forms.Label();
            this.setPointControlLabel = new System.Windows.Forms.Label();
            this.doubleClickPointSetCheckBox = new System.Windows.Forms.CheckBox();
            this.setRegionControlButton = new System.Windows.Forms.Button();
            this.regionControlSettingLabel = new System.Windows.Forms.Label();
            this.setRegionControlLabel = new System.Windows.Forms.Label();
            this.announcementSettingsGroup = new System.Windows.Forms.GroupBox();
            this.announcementSettingsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.unitsLabel = new System.Windows.Forms.Label();
            this.unitsSelector = new System.Windows.Forms.ComboBox();
            this.sayTenthsCheckBox = new System.Windows.Forms.CheckBox();
            this.sayMaxExitCheckBox = new System.Windows.Forms.CheckBox();
            this.sayMaxEntryCheckBox = new System.Windows.Forms.CheckBox();
            this.voiceLabel = new System.Windows.Forms.Label();
            this.voiceSelector = new System.Windows.Forms.ComboBox();
            this.voiceSpeedLabel = new System.Windows.Forms.Label();
            this.speedSelector = new System.Windows.Forms.NumericUpDown();
            this.voiceVolumeLabel = new System.Windows.Forms.Label();
            this.volumeSelector = new System.Windows.Forms.NumericUpDown();
            this.testAnnouncementButton = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dataLabel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.manageMarkersGroup.SuspendLayout();
            this.controlsSettingsGroup.SuspendLayout();
            this.announcementSettingsGroup.SuspendLayout();
            this.announcementSettingsLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSelector)).BeginInit();
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
            this.startStopButton.Text = "&Start";
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
            // markersList
            // 
            this.markersList.FormattingEnabled = true;
            this.markersList.Location = new System.Drawing.Point(2, 97);
            this.markersList.Margin = new System.Windows.Forms.Padding(2);
            this.markersList.Name = "markersList";
            this.markersList.Size = new System.Drawing.Size(390, 400);
            this.markersList.TabIndex = 2;
            this.markersList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.markersList_ItemCheck);
            this.markersList.SelectedIndexChanged += new System.EventHandler(this.pointsListBox_SelectedIndexChanged);
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
            this.gameControllersList.Location = new System.Drawing.Point(11, 339);
            this.gameControllersList.Name = "gameControllersList";
            this.gameControllersList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.gameControllersList.Size = new System.Drawing.Size(355, 124);
            this.gameControllersList.TabIndex = 3;
            // 
            // controllersLabel
            // 
            this.controllersLabel.AutoSize = true;
            this.controllersLabel.Location = new System.Drawing.Point(11, 316);
            this.controllersLabel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 0);
            this.controllersLabel.Name = "controllersLabel";
            this.controllersLabel.Size = new System.Drawing.Size(157, 20);
            this.controllersLabel.TabIndex = 2;
            this.controllersLabel.Text = "Connected controllers:";
            // 
            // trackMarkersLabel
            // 
            this.trackMarkersLabel.AutoSize = true;
            this.trackMarkersLabel.Location = new System.Drawing.Point(3, 75);
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
            this.manageMarkersGroup.Location = new System.Drawing.Point(3, 502);
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
            this.controlsSettingsGroup.Controls.Add(this.enableMarkerRecordingCheckBox);
            this.controlsSettingsGroup.Controls.Add(this.setPointControlButton);
            this.controlsSettingsGroup.Controls.Add(this.pointControlSettingLabel);
            this.controlsSettingsGroup.Controls.Add(this.setPointControlLabel);
            this.controlsSettingsGroup.Controls.Add(this.doubleClickPointSetCheckBox);
            this.controlsSettingsGroup.Controls.Add(this.setRegionControlButton);
            this.controlsSettingsGroup.Controls.Add(this.regionControlSettingLabel);
            this.controlsSettingsGroup.Controls.Add(this.setRegionControlLabel);
            this.controlsSettingsGroup.Location = new System.Drawing.Point(11, 469);
            this.controlsSettingsGroup.Name = "controlsSettingsGroup";
            this.controlsSettingsGroup.Size = new System.Drawing.Size(355, 158);
            this.controlsSettingsGroup.TabIndex = 4;
            this.controlsSettingsGroup.TabStop = false;
            this.controlsSettingsGroup.Text = "&Controls:";
            // 
            // enableMarkerRecordingCheckBox
            // 
            this.enableMarkerRecordingCheckBox.AutoSize = true;
            this.enableMarkerRecordingCheckBox.Checked = true;
            this.enableMarkerRecordingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableMarkerRecordingCheckBox.Location = new System.Drawing.Point(15, 128);
            this.enableMarkerRecordingCheckBox.Name = "enableMarkerRecordingCheckBox";
            this.enableMarkerRecordingCheckBox.Size = new System.Drawing.Size(194, 24);
            this.enableMarkerRecordingCheckBox.TabIndex = 8;
            this.enableMarkerRecordingCheckBox.Text = "&Enable marker recording";
            this.enableMarkerRecordingCheckBox.UseVisualStyleBackColor = true;
            this.enableMarkerRecordingCheckBox.CheckedChanged += new System.EventHandler(this.enableMarkerRecordingCheckBox_CheckedChanged);
            // 
            // setPointControlButton
            // 
            this.setPointControlButton.Location = new System.Drawing.Point(278, 82);
            this.setPointControlButton.Name = "setPointControlButton";
            this.setPointControlButton.Size = new System.Drawing.Size(71, 31);
            this.setPointControlButton.TabIndex = 7;
            this.setPointControlButton.Text = "Change";
            this.setPointControlButton.UseVisualStyleBackColor = true;
            this.setPointControlButton.Click += new System.EventHandler(this.setPointControlButton_Click);
            // 
            // pointControlSettingLabel
            // 
            this.pointControlSettingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pointControlSettingLabel.Location = new System.Drawing.Point(140, 84);
            this.pointControlSettingLabel.Name = "pointControlSettingLabel";
            this.pointControlSettingLabel.Size = new System.Drawing.Size(132, 27);
            this.pointControlSettingLabel.TabIndex = 5;
            this.pointControlSettingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.doubleClickPointSetCheckBox.TabIndex = 6;
            this.doubleClickPointSetCheckBox.Text = "Double click region button for point marker";
            this.doubleClickPointSetCheckBox.UseVisualStyleBackColor = true;
            this.doubleClickPointSetCheckBox.CheckedChanged += new System.EventHandler(this.doubleClickPointSetCheckBox_CheckedChanged);
            // 
            // setRegionControlButton
            // 
            this.setRegionControlButton.Location = new System.Drawing.Point(278, 19);
            this.setRegionControlButton.Name = "setRegionControlButton";
            this.setRegionControlButton.Size = new System.Drawing.Size(71, 31);
            this.setRegionControlButton.TabIndex = 5;
            this.setRegionControlButton.Text = "Change";
            this.setRegionControlButton.UseVisualStyleBackColor = true;
            this.setRegionControlButton.Click += new System.EventHandler(this.setRegionControlButton_Click);
            // 
            // regionControlSettingLabel
            // 
            this.regionControlSettingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regionControlSettingLabel.Location = new System.Drawing.Point(140, 21);
            this.regionControlSettingLabel.Name = "regionControlSettingLabel";
            this.regionControlSettingLabel.Size = new System.Drawing.Size(132, 27);
            this.regionControlSettingLabel.TabIndex = 1;
            this.regionControlSettingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setRegionControlLabel
            // 
            this.setRegionControlLabel.AutoSize = true;
            this.setRegionControlLabel.Location = new System.Drawing.Point(6, 23);
            this.setRegionControlLabel.Name = "setRegionControlLabel";
            this.setRegionControlLabel.Size = new System.Drawing.Size(129, 20);
            this.setRegionControlLabel.TabIndex = 0;
            this.setRegionControlLabel.Text = "Start / end region:";
            // 
            // announcementSettingsGroup
            // 
            this.announcementSettingsGroup.AutoSize = true;
            this.announcementSettingsGroup.Controls.Add(this.announcementSettingsLayoutPanel);
            this.announcementSettingsGroup.Location = new System.Drawing.Point(11, 79);
            this.announcementSettingsGroup.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.announcementSettingsGroup.Name = "announcementSettingsGroup";
            this.announcementSettingsGroup.Padding = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.announcementSettingsGroup.Size = new System.Drawing.Size(302, 218);
            this.announcementSettingsGroup.TabIndex = 1;
            this.announcementSettingsGroup.TabStop = false;
            this.announcementSettingsGroup.Text = "&Announcement settings";
            // 
            // announcementSettingsLayoutPanel
            // 
            this.announcementSettingsLayoutPanel.AutoSize = true;
            this.announcementSettingsLayoutPanel.Controls.Add(this.unitsLabel);
            this.announcementSettingsLayoutPanel.Controls.Add(this.unitsSelector);
            this.announcementSettingsLayoutPanel.Controls.Add(this.sayTenthsCheckBox);
            this.announcementSettingsLayoutPanel.Controls.Add(this.sayMaxExitCheckBox);
            this.announcementSettingsLayoutPanel.Controls.Add(this.sayMaxEntryCheckBox);
            this.announcementSettingsLayoutPanel.Controls.Add(this.voiceLabel);
            this.announcementSettingsLayoutPanel.Controls.Add(this.voiceSelector);
            this.announcementSettingsLayoutPanel.Controls.Add(this.voiceSpeedLabel);
            this.announcementSettingsLayoutPanel.Controls.Add(this.speedSelector);
            this.announcementSettingsLayoutPanel.Controls.Add(this.voiceVolumeLabel);
            this.announcementSettingsLayoutPanel.Controls.Add(this.volumeSelector);
            this.announcementSettingsLayoutPanel.Controls.Add(this.testAnnouncementButton);
            this.announcementSettingsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.announcementSettingsLayoutPanel.Location = new System.Drawing.Point(3, 36);
            this.announcementSettingsLayoutPanel.Name = "announcementSettingsLayoutPanel";
            this.announcementSettingsLayoutPanel.Size = new System.Drawing.Size(296, 179);
            this.announcementSettingsLayoutPanel.TabIndex = 10;
            // 
            // unitsLabel
            // 
            this.unitsLabel.Location = new System.Drawing.Point(3, 0);
            this.unitsLabel.Name = "unitsLabel";
            this.unitsLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.unitsLabel.Size = new System.Drawing.Size(52, 26);
            this.unitsLabel.TabIndex = 0;
            this.unitsLabel.Text = "Units:";
            this.unitsLabel.UseMnemonic = false;
            // 
            // unitsSelector
            // 
            this.unitsSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitsSelector.FormattingEnabled = true;
            this.unitsSelector.Items.AddRange(new object[] {
            "Metric",
            "Imperial"});
            this.unitsSelector.Location = new System.Drawing.Point(61, 3);
            this.unitsSelector.Name = "unitsSelector";
            this.unitsSelector.Size = new System.Drawing.Size(93, 28);
            this.unitsSelector.TabIndex = 1;
            this.unitsSelector.SelectedIndexChanged += new System.EventHandler(this.speedUnitSelector_SelectedIndexChanged);
            // 
            // sayTenthsCheckBox
            // 
            this.sayTenthsCheckBox.AutoSize = true;
            this.announcementSettingsLayoutPanel.SetFlowBreak(this.sayTenthsCheckBox, true);
            this.sayTenthsCheckBox.Location = new System.Drawing.Point(160, 3);
            this.sayTenthsCheckBox.Name = "sayTenthsCheckBox";
            this.sayTenthsCheckBox.Padding = new System.Windows.Forms.Padding(16, 4, 0, 0);
            this.sayTenthsCheckBox.Size = new System.Drawing.Size(114, 28);
            this.sayTenthsCheckBox.TabIndex = 2;
            this.sayTenthsCheckBox.Text = "Say tenths";
            this.sayTenthsCheckBox.UseVisualStyleBackColor = true;
            this.sayTenthsCheckBox.CheckedChanged += new System.EventHandler(this.sayTenthsCheckBox_CheckedChanged);
            // 
            // sayMaxExitCheckBox
            // 
            this.sayMaxExitCheckBox.AutoSize = true;
            this.sayMaxExitCheckBox.Location = new System.Drawing.Point(3, 37);
            this.sayMaxExitCheckBox.Name = "sayMaxExitCheckBox";
            this.sayMaxExitCheckBox.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.sayMaxExitCheckBox.Size = new System.Drawing.Size(138, 24);
            this.sayMaxExitCheckBox.TabIndex = 3;
            this.sayMaxExitCheckBox.Text = "Say max exit";
            this.sayMaxExitCheckBox.UseVisualStyleBackColor = true;
            this.sayMaxExitCheckBox.CheckedChanged += new System.EventHandler(this.sayMaxExitCheckBox_CheckedChanged);
            // 
            // sayMaxEntryCheckBox
            // 
            this.sayMaxEntryCheckBox.AutoSize = true;
            this.announcementSettingsLayoutPanel.SetFlowBreak(this.sayMaxEntryCheckBox, true);
            this.sayMaxEntryCheckBox.Location = new System.Drawing.Point(147, 37);
            this.sayMaxEntryCheckBox.Name = "sayMaxEntryCheckBox";
            this.sayMaxEntryCheckBox.Size = new System.Drawing.Size(123, 24);
            this.sayMaxEntryCheckBox.TabIndex = 4;
            this.sayMaxEntryCheckBox.Text = "Say max entry";
            this.sayMaxEntryCheckBox.UseVisualStyleBackColor = true;
            this.sayMaxEntryCheckBox.CheckedChanged += new System.EventHandler(this.sayMaxEntryCheckBox_CheckedChanged);
            // 
            // voiceLabel
            // 
            this.voiceLabel.Location = new System.Drawing.Point(3, 64);
            this.voiceLabel.Name = "voiceLabel";
            this.voiceLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.voiceLabel.Size = new System.Drawing.Size(52, 26);
            this.voiceLabel.TabIndex = 5;
            this.voiceLabel.Text = "Voice:";
            // 
            // voiceSelector
            // 
            this.voiceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.announcementSettingsLayoutPanel.SetFlowBreak(this.voiceSelector, true);
            this.voiceSelector.FormattingEnabled = true;
            this.voiceSelector.Location = new System.Drawing.Point(61, 67);
            this.voiceSelector.Name = "voiceSelector";
            this.voiceSelector.Size = new System.Drawing.Size(232, 28);
            this.voiceSelector.TabIndex = 6;
            // 
            // voiceSpeedLabel
            // 
            this.voiceSpeedLabel.Location = new System.Drawing.Point(3, 98);
            this.voiceSpeedLabel.Name = "voiceSpeedLabel";
            this.voiceSpeedLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.voiceSpeedLabel.Size = new System.Drawing.Size(72, 26);
            this.voiceSpeedLabel.TabIndex = 7;
            this.voiceSpeedLabel.Text = "Speed:";
            // 
            // speedSelector
            // 
            this.speedSelector.Location = new System.Drawing.Point(81, 101);
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
            this.speedSelector.TabIndex = 8;
            this.speedSelector.ValueChanged += new System.EventHandler(this.speedSelector_ValueChanged);
            // 
            // voiceVolumeLabel
            // 
            this.voiceVolumeLabel.Location = new System.Drawing.Point(150, 98);
            this.voiceVolumeLabel.Name = "voiceVolumeLabel";
            this.voiceVolumeLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.voiceVolumeLabel.Size = new System.Drawing.Size(67, 26);
            this.voiceVolumeLabel.TabIndex = 7;
            this.voiceVolumeLabel.Text = "Volume:";
            // 
            // volumeSelector
            // 
            this.announcementSettingsLayoutPanel.SetFlowBreak(this.volumeSelector, true);
            this.volumeSelector.Location = new System.Drawing.Point(223, 101);
            this.volumeSelector.Name = "volumeSelector";
            this.volumeSelector.Size = new System.Drawing.Size(63, 27);
            this.volumeSelector.TabIndex = 9;
            this.volumeSelector.ValueChanged += new System.EventHandler(this.volumeSelector_ValueChanged);
            // 
            // testAnnouncementButton
            // 
            this.testAnnouncementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testAnnouncementButton.Location = new System.Drawing.Point(58, 147);
            this.testAnnouncementButton.Margin = new System.Windows.Forms.Padding(58, 16, 3, 3);
            this.testAnnouncementButton.Name = "testAnnouncementButton";
            this.testAnnouncementButton.Size = new System.Drawing.Size(103, 29);
            this.testAnnouncementButton.TabIndex = 10;
            this.testAnnouncementButton.Text = "&Test";
            this.testAnnouncementButton.UseVisualStyleBackColor = true;
            this.testAnnouncementButton.Click += new System.EventHandler(this.testAnnouncementButton_Click);
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
            this.rightPanel.Controls.Add(this.markersList);
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
            this.dataLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dataLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataLabel.Location = new System.Drawing.Point(8, 20);
            this.dataLabel.Margin = new System.Windows.Forms.Padding(8, 20, 8, 8);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Padding = new System.Windows.Forms.Padding(4);
            this.dataLabel.Size = new System.Drawing.Size(378, 31);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.announcementSettingsLayoutPanel.ResumeLayout(false);
            this.announcementSettingsLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSelector)).EndInit();
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
        private CheckedListBox markersList;
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
        private Label pointControlSettingLabel;
        private Label setPointControlLabel;
        private CheckBox doubleClickPointSetCheckBox;
        private Button setRegionControlButton;
        private Label regionControlSettingLabel;
        private Label setRegionControlLabel;
        private GroupBox announcementSettingsGroup;
        private Button testAnnouncementButton;
        private Label unitsLabel;
        private ComboBox unitsSelector;
        private CheckBox sayTenthsCheckBox;
        private ComboBox voiceSelector;
        private Label voiceLabel;
        private Label voiceSpeedLabel;
        private NumericUpDown speedSelector;
        private FlowLayoutPanel leftPanel; 
        private Label voiceVolumeLabel;
        private NumericUpDown volumeSelector;
        private FlowLayoutPanel rightPanel;
        private Label dataLabel;
        private CheckBox sayMaxExitCheckBox;
        private CheckBox sayMaxEntryCheckBox;
        private FlowLayoutPanel announcementSettingsLayoutPanel;
        private CheckBox enableMarkerRecordingCheckBox;
    }
}