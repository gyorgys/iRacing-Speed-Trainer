namespace IRacingSpeedTrainer
{
    using iRacingSDK;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Speech.Synthesis;
    using SharpDX.DirectInput;
 
    public partial class MainForm : Form
    {
        private TelemetryConnection? iRacing = null;
        private float currentDistance = -1;
        private TrackData? trackData = null;
        private string fullTrackName = "";
        private SpeechSynthesizer synth = new SpeechSynthesizer();
        private GameControllers controllers = new GameControllers();
        private TrackPositionMonitor monitor = new TrackPositionMonitor(new List<TrackMarker>());

        private event EventHandler<string>? NextInputDetected = null;

        private DateTime sectionMarkTime = DateTime.Now;
        private float? sectionMarkDistance = null;

        public MainForm()
        {
            InitializeComponent();
            UpdateConnectionState();
            UpdateCarState();
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            synth.Rate = 2;
            this.controllers.IsMonitoredOnly = true;
            this.controllers.ControllersChanged += Controllers_ControllersChanged;
            this.controllers.InputsChanged += Controllers_InputsChanged;
            this.addPositionButton.Enabled = false;
            this.addRegionButton.Enabled = false;
            this.deleteMarkerButton.Enabled = false;
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

        private void Controllers_ControllersChanged(object? sender, IReadOnlyList<ControllerInfo> controllers)
        {
            this.gameControllersList.DataSource = null;
            this.gameControllersList.DataSource = controllers;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UserSettings.Default.Save();
            this.controllers.Dispose();
            if (this.trackData?.IsDirty ?? false)
            {
                this.trackData?.Save();
            }
            this.iRacing?.Dispose();
            this.iRacing = null;
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
            this.dataLabel.Text = state.ToString();
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

        private void IRacing_CurrentTrackChanged(object? sender, TrackInfo? track)
        {
            UpdateStatusLabel();
            SetCurrentTrack(track);
        }

        private void IRacing_NewTelemetryData(object? sender, Telemetry tele)
        {
            this.currentDistance = tele.LapDist;
            monitor.ProcessNewData(tele);
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
                this.pointsListBox.DataSource = null;
            }
            if (track != null)
            {
                this.trackData = new TrackData(track.Name);
                this.trackData.MarkersChanged += TrackData_MarkersChanged;
                this.pointsListBox.DataSource = null;
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
            this.pointsListBox.DataSource = new List<TrackMarker>(markers);
            this.monitor.UpdateMarkers(markers);
        }

        private void AnnounceSpeed(double speed, float point)
        {
            int hunderds = (int)Math.Floor(speed / 100);
            double remainder = speed % 100;
            var promptBuilder = new PromptBuilder();
            if (hunderds > 0)
            {
                promptBuilder.AppendText(hunderds.ToString());
                promptBuilder.AppendText(" ");
            }
            promptBuilder.AppendText(remainder.ToString("0.0"));
            synth.Speak(promptBuilder);
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
                this.trackData?.AddMarker(new TrackMarker(distance));
                //this.pointsListBox.DataSource = this.trackData?.Markers;
            }
        }

        private void AddSectionMarker(float startDistance, float endDistance)
        {
            if (startDistance >= 0)
            {
                this.trackData?.AddMarker(new TrackMarker(startDistance, endDistance));
                //this.pointsListBox.DataSource = this.trackData?.Markers;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateControlScheme();
            this.controllers.StartListening(this);
            this.gameControllersList.DataSource = this.controllers.ConnectedControllers;
            this.monitor.PointPassed += Monitor_PointPassed;
            this.monitor.RegionPassed += Monitor_RegionPassed;
        }

        private void Monitor_RegionPassed(object? sender, TrackPositionMonitor.MultiTelemetryEventArgs e)
        {
            var minSpeedPoint = e.Teles.MinBy(tele => tele.Speed);
            var maxBefore = e.Teles.Where(tele => tele.LapDist < minSpeedPoint.LapDist).MaxBy(tele => tele.Speed);
            var maxAfter = e.Teles.Where(tele => tele.LapDist >= minSpeedPoint.LapDist).MaxBy(tele => tele.Speed); 

            if (minSpeedPoint != null && maxBefore != null && maxAfter != null)
            {
                var minSpeed = Math.Round(minSpeedPoint.Speed * 2.23694, 1);
                var maxBeforeSpeed = Math.Round(maxBefore.Speed * 2.23694, 1);
                var maxAfterSpeed = Math.Round(maxAfter.Speed * 2.23694, 1);
                this.AnnounceSpeed(maxBeforeSpeed, maxBefore.LapDist);
                this.AnnounceSpeed(minSpeed, minSpeedPoint.LapDist);
                this.AnnounceSpeed(maxAfterSpeed, maxAfter.LapDist);
            }
        }

        private void Monitor_PointPassed(object? sender, TrackPositionMonitor.SingleTelemetryEventArgs e)
        {
            var speed = Math.Round(e.Tele.Speed * 2.23694, 1);
            this.AnnounceSpeed(speed, e.Marker.Start);
        }

        private void pointsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.deleteMarkerButton.Enabled = pointsListBox.SelectedIndex >= 0;
        }

        private void doubleClickPointSetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Default.DoubleClickForPointMarker = doubleClickPointSetCheckBox.Checked;
            this.UpdateControlScheme();
        }

        private void UpdateControlScheme()
        {
            var settings = UserSettings.Default;
            this.regionControlTextBox.Text = settings.StartStopRegionControl;
            this.pointControlTextBox.Text = settings.SetPointControl;
            this.doubleClickPointSetCheckBox.Checked = settings.DoubleClickForPointMarker;
            controllers.MonitoredInputSet.Clear();
            if (settings.StartStopRegionControl.Length > 0)
            {
                controllers.MonitoredInputSet.Add(settings.StartStopRegionControl);
            }
            if (settings.DoubleClickForPointMarker)
            {
                this.setPointControlLabel.Visible = false;
                this.pointControlTextBox.Visible = false;
                this.setPointControlButton.Visible = false;
            }
            else
            {
                this.setPointControlLabel.Visible = true;
                this.pointControlTextBox.Visible = true;
                this.setPointControlButton.Visible = true;
                if (settings.SetPointControl.Length > 0)
                {
                    controllers.MonitoredInputSet.Add(settings.SetPointControl);
                }
            }
        }

        private void setRegionControlButton_Click(object sender, EventArgs e)
        {
            this.regionControlTextBox.Text = "<press>";
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
            this.pointControlTextBox.Text = "<press>";
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
    }
}