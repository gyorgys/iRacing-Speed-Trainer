namespace IRacingSpeedTrainer
{
    using iRacingSDK;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Speech.Synthesis;
    using SharpDX.DirectInput;
    using System.Collections.Concurrent;
    using System.Media;

    public partial class MainForm : Form
    {
        private TelemetryConnection? iRacing = null;
        private float currentDistance = -1;
        private float currentSpeed = 0;
        private TrackData? trackData = null;
        private string fullTrackName = "";
        private SpeechSynthesizer synth = new SpeechSynthesizer();
        private ConcurrentQueue<Prompt> announcementQueue = new ConcurrentQueue<Prompt>();
        private AutoResetEvent newAnnouncementEvent = new AutoResetEvent(false);
        private bool isShutdown = false;
        private Task? announcementTask = null;
        private GameControllers controllers = new GameControllers();
        private TrackPositionMonitor monitor = new TrackPositionMonitor(new List<TrackMarker>());

        private event EventHandler<string>? NextInputDetected = null;

        private DateTime sectionMarkTime = DateTime.Now;
        private float? sectionMarkDistance = null;

        private bool updatingAnnouncementSettings = false;
        private bool updatingControlSettings = false;
        private string distanceMetric = "m";
        private float distanceConversion = 1f;
        private float speedConversion = 3.6f;

        public MainForm()
        {
            InitializeComponent();
            UpdateConnectionState();
            UpdateCarState();
            synth.SetOutputToDefaultAudioDevice();
            synth.Rate = 2;
            this.controllers.IsMonitoredOnly = true;
            this.controllers.ControllersChanged += Controllers_ControllersChanged;
            this.controllers.InputsChanged += Controllers_InputsChanged;
            this.addPositionButton.Enabled = false;
            this.addRegionButton.Enabled = false;
            this.deleteMarkerButton.Enabled = false;
            this.voiceSelector.DataSource = synth.GetInstalledVoices().Select(v => v.VoiceInfo.Name).ToList();
            this.voiceSelector.SelectedIndexChanged += VoiceSelector_SelectedIndexChanged;
        }

        private void Controllers_InputsChanged(object? sender, IReadOnlySet<string> newInputs)
        {
            if (newInputs.Count > 0)
            {
                if (this.NextInputDetected != null)
                {
                    controllers.IsMonitoredOnly = true;
                    this.NextInputDetected?.Invoke(this, newInputs.First());
                }
                else
                {
                    var input = newInputs.First();
                    if (UserSettings.Default.EnableMarkerRecording)
                    {
                        if (this.sectionMarkDistance == null)
                        {
                            if (input == UserSettings.Default.SetPointControl)
                            {
                                this.AddPointMarker(this.currentDistance);
                            }
                            else if (input == UserSettings.Default.StartStopRegionControl)
                            {
                                this.sectionMarkDistance = this.currentDistance;
                                this.sectionMarkTime = DateTime.Now;
                                SystemSounds.Exclamation.Play();
                            }
                        }
                        else
                        {
                            if (input == UserSettings.Default.StartStopRegionControl)
                            {
                                if (UserSettings.Default.DoubleClickForPointMarker && (DateTime.Now - this.sectionMarkTime).TotalSeconds < 1)
                                {
                                    this.AddPointMarker(this.sectionMarkDistance ?? 0);
                                }
                                else
                                {
                                    this.AddSectionMarker(this.sectionMarkDistance ?? 0, this.currentDistance);
                                }
                                this.sectionMarkDistance = null;
                            }
                        }
                    }
                }
            }
        }

        private void Controllers_ControllersChanged(object? sender, IReadOnlyList<ControllerInfo> controllers)
        {
            this.gameControllersList.DataSource = null;
            this.gameControllersList.DataSource = controllers;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.isShutdown = true;
            this.newAnnouncementEvent.Set();
            UserSettings.Default.Save();
            this.controllers.Dispose();
            if (this.trackData?.IsDirty ?? false)
            {
                this.trackData?.Save();
            }
            this.iRacing?.Dispose();
            this.iRacing = null;
            this.newAnnouncementEvent.Dispose();
            this.announcementTask?.Wait();
            // for some reason this takes forever
            // this.announcementTask?.Dispose();
            this.announcementTask = null;
            base.OnFormClosing(e);
        }

        private void UpdateConnectionState()
        {
            switch(this.iRacing?.ConnectionState ?? TelemetryConnection.ConnectionStates.Stopped)
            {
                case TelemetryConnection.ConnectionStates.Stopped:
                    this.startStopButton.Text = "Start";
                    this.startStopButton.Enabled = true;
                    break;
                case TelemetryConnection.ConnectionStates.Listening:
                    this.startStopButton.Text = "Stop";
                    this.startStopButton.Enabled = true;
                    break;
                case TelemetryConnection.ConnectionStates.Error:
                    this.startStopButton.Text = "Start";
                    this.startStopButton.Enabled = false;
                    break;
                case TelemetryConnection.ConnectionStates.Connected:
                    this.startStopButton.Text = "Stop";
                    this.startStopButton.Enabled = true;
                    break;
            }
            this.UpdateStatusLabel();
        }

        private void UpdateCarState()
        {
            var state = this.iRacing?.CarState ?? TelemetryConnection.CarStates.None;
            this.UpdateDataLabel();
        }
        
        private void UpdateStatusLabel()
        {
            switch (this.iRacing?.ConnectionState ?? TelemetryConnection.ConnectionStates.Stopped)
            {
                case TelemetryConnection.ConnectionStates.Stopped:
                    this.toolStripStatusLabel.Text = "Stopped";
                    break;
                case TelemetryConnection.ConnectionStates.Listening:
                    this.toolStripStatusLabel.Text = "Listening";
                    break;
                case TelemetryConnection.ConnectionStates.Error:
                    this.toolStripStatusLabel.Text = "Error";
                    break;
                case TelemetryConnection.ConnectionStates.Connected:
                    this.toolStripStatusLabel.Text = String.Format(
                        "Connected: {0}", this.iRacing?.CurrentTrack?.DisplayName ?? "");
                    break;
            }
        }
        private void UpdateDataLabel()
        {
            switch (this.iRacing?.CarState ?? TelemetryConnection.CarStates.None)
            {
                case TelemetryConnection.CarStates.None:
                    this.dataLabel.Text = "";
                    break;
                case TelemetryConnection.CarStates.InMenus:
                    this.dataLabel.Text = "iRacing Menu";
                    break;
                case TelemetryConnection.CarStates.InPits:
                    this.dataLabel.Text = "Pit";
                    break;
                case TelemetryConnection.CarStates.OnTrack:
                    string currentDistText = this.sectionMarkDistance != null ?
                        String.Format("{0,6:0.0} - {0,6:0.0}", this.sectionMarkDistance, this.currentDistance) :
                        String.Format("{0,6:0.0}", this.currentDistance);
                    string speedText = String.Format("{0,5:0.0}", this.currentSpeed * this.speedConversion);
                    this.dataLabel.Text = String.Format("{0} {1}    {2}", speedText, UserSettings.Default.Units, currentDistText);
                    break;
            }
        }

        private void StartListening()
        {
            if (this.iRacing == null)
            {
                this.iRacing = new TelemetryConnection();
                this.iRacing.ConnectionStateChanged += IRacing_ConnectionStateChanged;
                this.iRacing.CarStateChanged += IRacing_CarStateChanged;
                this.iRacing.NewTelemetryData += IRacing_NewTelemetryData;
                this.iRacing.CurrentTrackChanged += IRacing_CurrentTrackChanged;
            }
            this.iRacing.Start();
        }

        private void AnnouncementTask()
        {
            while(!this.isShutdown)
            {
                this.newAnnouncementEvent.WaitOne();
                Trace.TraceInformation("Announcement task signalled");
                Prompt? prompt = null;
                while(this.announcementQueue.TryDequeue(out prompt))
                {
                    Trace.TraceInformation("Announcement task speaking");
                    this.synth.Speak(prompt);
                }
            }
            Trace.TraceInformation("Announcement task exited");
        }

        private void IRacing_CurrentTrackChanged(object? sender, TrackInfo? track)
        {
            UpdateStatusLabel();
            SetCurrentTrack(track);
        }

        private void IRacing_NewTelemetryData(object? sender, Telemetry tele)
        {
            this.currentDistance = tele.LapDist;
            this.currentSpeed = tele.Speed;
            monitor.ProcessNewData(tele);
            this.UpdateDataLabel();
        }

        private void IRacing_CarStateChanged(object? sender, TelemetryConnection.CarStates e)
        {
            Trace.TraceInformation(String.Format("Car State {0}", e.ToString()));
            this.UpdateCarState();
        }

        private void IRacing_ConnectionStateChanged(object? sender, TelemetryConnection.ConnectionStates e)
        {
            Trace.TraceInformation(String.Format("Connection State {0}", e.ToString()));
            this.UpdateConnectionState();
        }

        private void SetCurrentTrack(TrackInfo? track)
        {
            if (this.trackData?.TrackName == track?.Name)
            {
                return;
            }
            this.fullTrackName = track?.DisplayName ?? "";
            if (this.trackData != null)
            {
                if (this.trackData.IsDirty)
                {
                    this.trackData.Save();
                }
                this.trackData = null;
                this.addPositionButton.Enabled = false;
                this.markersList.DataSource = null;
            }
            if (track != null)
            {
                this.trackData = new TrackData(track.Name);
                this.trackData.MarkersChanged += TrackData_MarkersChanged;
                this.markersList.DataSource = null;
                this.trackData.Load();
                this.addPositionButton.Enabled = true;
                this.addRegionButton.Enabled = true;
            }
            else
            {
                this.addPositionButton.Enabled = false;
                this.addRegionButton.Enabled = false;
                this.deleteMarkerButton.Enabled = false;
            }
            this.UpdateStatusLabel();
        }

        private void TrackData_MarkersChanged(object? sender, IList<TrackMarker> markers)
        {
            this.markersList.DataSource = new List<TrackMarker>(markers);
            this.monitor.UpdateMarkers(markers);
        }

        private void AnnounceSpeed(IList<float> speeds)
        {
            var promptBuilder = new PromptBuilder();
            string format = UserSettings.Default.SayTenths ? "0.0" : "0";
            var convertedSpeeds = speeds.Select(s => s * this.speedConversion).ToArray();
            foreach (var convertedSpeed in convertedSpeeds)
            {
                int hunderds = (int)Math.Floor(convertedSpeed / 100);
                double remainder = convertedSpeed % 100;
                if (hunderds > 0)
                {
                    promptBuilder.AppendText(hunderds.ToString());
                    promptBuilder.AppendText(" ");
                }
                promptBuilder.AppendText(remainder.ToString(format));
                promptBuilder.AppendBreak(PromptBreak.ExtraSmall);
            }
            this.announcementQueue.Enqueue(new Prompt(promptBuilder));
            this.newAnnouncementEvent.Set();
        }

        private void StopListening()
        {
            this.iRacing?.Stop();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            var state = this.iRacing?.ConnectionState ?? TelemetryConnection.ConnectionStates.Stopped;
            if(state == TelemetryConnection.ConnectionStates.Stopped)
            {
                this.StartListening();
            } 
            else
            {
                this.StopListening();
            }
        }

        private void AddPointMarker(float distance)
        {
            if (distance >= 0)
            {
                bool success = this.trackData?.AddMarker(new TrackMarker(distance)) ?? false;
                if (success)
                {
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    SystemSounds.Hand.Play();
                }
            }
        }

        private void AddSectionMarker(float startDistance, float endDistance)
        {
            if (startDistance >= 0)
            {
                bool success = this.trackData?.AddMarker(new TrackMarker(startDistance, endDistance)) ?? false;
                if (success)
                {
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    SystemSounds.Hand.Play();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateControlScheme();
            UpdateAnnouncementSettings();
            this.controllers.StartListening(this);
            this.gameControllersList.DataSource = this.controllers.ConnectedControllers;
            this.monitor.PointPassed += Monitor_PointPassed;
            this.monitor.RegionPassed += Monitor_RegionPassed;
            this.announcementTask = new Task(AnnouncementTask);
            this.announcementTask.Start();
            this.enableMarkerRecordingCheckBox.Checked = UserSettings.Default.EnableMarkerRecording;
        }

        private void Monitor_RegionPassed(object? sender, TrackPositionMonitor.MultiTelemetryEventArgs e)
        {
            var minSpeedPoint = e.Teles.MinBy(tele => tele.Speed);
            if (minSpeedPoint == null)
            {
                return;
            }
            var maxBefore = e.Teles.Where(tele => tele.LapDist < minSpeedPoint.LapDist).MaxBy(tele => tele.Speed);
            var maxAfter = e.Teles.Where(tele => tele.LapDist >= minSpeedPoint.LapDist).MaxBy(tele => tele.Speed); 

            if (minSpeedPoint != null && maxBefore != null && maxAfter != null)
            {
                List<float> speeds = new List<float>();
                if (UserSettings.Default.SayMaxEntrySpeed)
                {
                    speeds.Add(maxBefore.Speed);
                }
                speeds.Add(minSpeedPoint.Speed);
                if (UserSettings.Default.SayMaxExitSpeed)
                {
                    speeds.Add(maxAfter.Speed);
                }
                this.AnnounceSpeed(speeds);
            }
        }

        private void Monitor_PointPassed(object? sender, TrackPositionMonitor.SingleTelemetryEventArgs e)
        {
            this.AnnounceSpeed(new float[] { e.Tele.Speed });
        }

        private void pointsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.deleteMarkerButton.Enabled = markersList.SelectedIndex >= 0;
        }

        private void doubleClickPointSetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.DoubleClickForPointMarker = doubleClickPointSetCheckBox.Checked;
            this.UpdateControlScheme();
        }

        private void UpdateControlScheme()
        {
            if(this.updatingControlSettings)
            {
                return;
            }
            this.updatingControlSettings = true;
            try 
            {
                var settings = UserSettings.Default;
                this.regionControlSettingLabel.Text = settings.StartStopRegionControl;
                this.pointControlSettingLabel.Text = settings.SetPointControl;
                this.doubleClickPointSetCheckBox.Checked = settings.DoubleClickForPointMarker;
                controllers.MonitoredInputSet.Clear();
                if (settings.StartStopRegionControl.Length > 0)
                {
                    controllers.MonitoredInputSet.Add(settings.StartStopRegionControl);
                }
                if (settings.DoubleClickForPointMarker)
                {
                    this.setPointControlLabel.Visible = false;
                    this.pointControlSettingLabel.Visible = false;
                    this.setPointControlButton.Visible = false;
                }
                else
                {
                    this.setPointControlLabel.Visible = true;
                    this.pointControlSettingLabel.Visible = true;
                    this.setPointControlButton.Visible = true;
                    if (settings.SetPointControl.Length > 0)
                    {
                        controllers.MonitoredInputSet.Add(settings.SetPointControl);
                    }
                }
            } 
            finally
            {
                this.updatingControlSettings = false;
            }
        }

        private void UpdateAnnouncementSettings()
        {
            if (this.updatingAnnouncementSettings)
            {
                return;
            }
            this.updatingAnnouncementSettings = true;
            try
            {
                var settings = UserSettings.Default;
                this.unitsSelector.SelectedIndex = settings.Units;
                this.sayTenthsCheckBox.Checked = settings.SayTenths;
                this.speedSelector.Value = settings.VoiceSpeed;
                this.voiceSelector.SelectedItem = settings.Voice;
                this.volumeSelector.Value = settings.Volume;
                synth.SelectVoice(this.voiceSelector.SelectedItem.ToString());
                synth.Rate = settings.VoiceSpeed;
                synth.Volume = settings.Volume;
                this.sayMaxExitCheckBox.Checked = settings.SayMaxExitSpeed;
                this.sayMaxEntryCheckBox.Checked = settings.SayMaxEntrySpeed;
                this.distanceMetric = settings.Units == 0 ? "m" : "ft";
                this.distanceConversion = settings.Units == 0 ? 1f : 3.28084f;
                this.speedConversion = UserSettings.Default.Units == 0 ? 2.23694f : 3.6f;
                this.labelM1.Text = this.distanceMetric;
                this.labelM2.Text = this.distanceMetric;
                if (TrackMarker.DistanceConversion != this.distanceConversion)
                {
                    TrackMarker.DistanceLabel = this.distanceMetric;
                    TrackMarker.DistanceConversion = this.distanceConversion;
                    if (this.trackData != null)
                    {
                        this.markersList.DataSource = new List<TrackMarker>(this.trackData.Markers);
                    }
                }
            }
            finally
            {
                this.updatingAnnouncementSettings = false;
            }

        }

        private void setRegionControlButton_Click(object sender, EventArgs e)
        {
            this.regionControlSettingLabel.Text = "<press>";
            controllers.IsMonitoredOnly = false;
            this.NextInputDetected += MainForm_SetRegionControlDetected;
        }

        private void MainForm_SetRegionControlDetected(object? sender, string input)
        {
            if (input != "Escape")
            {
                UserSettings.Default.StartStopRegionControl = input;
            }
            this.NextInputDetected = null;
            this.UpdateControlScheme();
        }

        private void setPointControlButton_Click(object sender, EventArgs e)
        {
            this.pointControlSettingLabel.Text = "<press>";
            controllers.IsMonitoredOnly = false;
            this.NextInputDetected += MainForm_PointControlDetected;
        }

        private void MainForm_PointControlDetected(object? sender, string input)
        {
            if (input != "Escape")
            {
                UserSettings.Default.SetPointControl = input;
            }
            this.NextInputDetected = null;
            this.UpdateControlScheme();
        }

        private void addRegionButton_Click(object sender, EventArgs e)
        {
            if (this.trackData == null)
            {
                this.ErrorPrompt("Adding section failed", "No track loaded.");
                return;
            }
            float startDistance = 0f;
            float endDistance = 0f;
            if (!Single.TryParse(this.regionStartDistanceTextBox.Text, out startDistance))
            {
                this.ErrorPrompt("Adding section failed", "Start position must be a valid floating point number.");
                return;
            }
            if (!Single.TryParse(this.regionEndDistanceTextBox.Text, out endDistance))
            {
                this.ErrorPrompt("Adding section failed", "End position must be a valid floating point number.");
                return;
            }
            bool success = this.trackData.AddMarker(new TrackMarker(startDistance, endDistance));
            if (!success)
            {
                this.ErrorPrompt("Adding point failed", "Position overlaps existing marker.");
            }

        }

        private void addPositionButton_Click(object sender, EventArgs e)
        {
            if (this.trackData == null)
            {
                this.ErrorPrompt("Adding point failed", "No track loaded.");
                return;
            }
            float distance = 0f;
            if (Single.TryParse(this.pointDistanceTextBox.Text, out distance))
            {
                bool success = this.trackData.AddMarker(new TrackMarker(distance));
                if (!success)
                {
                    this.ErrorPrompt("Adding point failed", "Position overlaps existing marker.");
                }
            }
            else
            {
                this.ErrorPrompt("Adding point failed", "Position must be a valid floating point number.");
            }
        }

        private void deleteMarkerButton_Click(object sender, EventArgs e)
        {
            var marker = markersList.SelectedItem as TrackMarker;
            if (marker != null)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete marker " + marker.ToString() + "?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.trackData?.DeleteMarkerAt(marker.Start);
                }
            }
        }

        private void ErrorPrompt(string title, string message)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void speedUnitSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserSettings.Default.Units = unitsSelector.SelectedIndex;
            UpdateAnnouncementSettings();
        }

        private void sayTenthsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.SayTenths = sayTenthsCheckBox.Checked;
            UpdateAnnouncementSettings();
        }

        private void testAnnouncementButton_Click(object sender, EventArgs e)
        {
            List<float> speeds = new List<float>();
            if (UserSettings.Default.SayMaxEntrySpeed)
            {
                speeds.Add(40f);
            }
            speeds.Add(15f);
            if (UserSettings.Default.SayMaxExitSpeed)
            {
                speeds.Add(25f);
            }
            this.AnnounceSpeed(speeds);
        }

        private void VoiceSelector_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UserSettings.Default.Voice = this.voiceSelector.SelectedItem.ToString();
            UpdateAnnouncementSettings();
        }

        private void speedSelector_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.VoiceSpeed = (int)speedSelector.Value;
            UpdateAnnouncementSettings();
        }

        private void sayMaxEntryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.SayMaxEntrySpeed = sayMaxEntryCheckBox.Checked;
            UpdateAnnouncementSettings();
        }

        private void sayMaxExitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.SayMaxExitSpeed = sayMaxExitCheckBox.Checked;
            UpdateAnnouncementSettings();
        }

        private void enableMarkerRecordingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.EnableMarkerRecording = enableMarkerRecordingCheckBox.Checked;
        }

        private void volumeSelector_ValueChanged(object sender, EventArgs e)
        {
            UserSettings.Default.Volume = (int)volumeSelector.Value;
            UpdateAnnouncementSettings();
        }
    }
}