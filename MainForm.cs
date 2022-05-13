namespace IRacingSpeedTrainer
{
    using iRacingSDK;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Speech.Synthesis;

    public partial class MainForm : Form
    {
        private TelemetryConnection? iRacing = null;
        private float currentDistance = -1;
        private float currentDistancePct = -1;
        private float currentSpeedMps = 0;
        private TrackSpeedMarkerData? trackMarkers = null;
        private string fullTrackName = "";
        private SpeechSynthesizer synth = new SpeechSynthesizer();

        public MainForm()
        {
            InitializeComponent();
            UpdateConnectionState();
            UpdateCarState();
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            synth.Rate = 2;
        }

        private void UpdateConnectionState()
        {
            this.speedLabel.Text = "";
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
            this.toolStripDataLabel.Text = state.ToString();
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
        }

        private void IRacing_NewTelemetryData(object? sender, Telemetry tele)
        {
            this.currentSpeedMps = tele.Speed;
            var speed = Math.Round(this.currentSpeedMps * 2.23694, 1);
            float previousDistance = this.currentDistance;
            this.currentDistance = tele.LapDist;
            this.currentDistancePct = tele.LapDistPct * 100.0f;
            this.toolStripDataLabel.Text = String.Format("Speed: {0} @{1:0.0}({2:0.00}%)", speed, this.currentDistance, this.currentDistancePct);
            if (previousDistance >= 0 && this.trackMarkers != null)
            {
                foreach (var marker in this.trackMarkers.Markers)
                {
                    if (!marker.IsRegion)
                        if (previousDistance < marker.Start && this.currentDistance >= marker.Start)
                        {
                            this.AnnounceSpeed(speed, marker.Start);
                        }
                }
            }
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

        private void SetCurrentTrack(string? trackName, string? fullTrackName)
        {
            if (this.trackMarkers?.TrackName == trackName)
            {
                return;
            }
            this.fullTrackName = fullTrackName ?? "";
            if (this.trackMarkers != null)
            {
                if (this.trackMarkers.IsDirty)
                {
                    this.trackMarkers.Save();
                }
                this.trackMarkers = null;
                this.addPosButton.Enabled = false;
            }
            if (trackName != null)
            {
                this.trackMarkers = new TrackSpeedMarkerData(trackName);
                this.trackMarkers.Load();
                this.pointsListBox.DataSource = this.trackMarkers.Markers;
                this.addPosButton.Enabled = true;
            }
            this.UpdateStatusLabel();
        }

        private void IRacing_NewSessionData(DataSample obj)
        {
            var data = obj.SessionData;
            if (data != null)
            { 
                this.SetCurrentTrack(data.WeekendInfo.TrackName, String.Format("{0} - {1}", data.WeekendInfo.TrackDisplayShortName, data.WeekendInfo.TrackConfigName)); 
                Trace.TraceInformation(String.Format("New session on {0}", data.WeekendInfo.TrackName));
            }
            else
            {
                this.SetCurrentTrack(null, null);
                Trace.TraceWarning("New session with no track");
            }
        }

        private void AnnounceSpeed(double speed, float point)
        {
            this.speedLabel.Text = String.Format("{0} MPH @ {1:0.0}", speed, point);
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

        private void addPosButton_Click(object sender, EventArgs e)
        {
            var distance = this.currentDistance;
            if (distance >= 0)
            {
                this.trackMarkers?.Markers.Add(new SpeedMarker { Start = distance});
                this.trackMarkers?.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double speed = Double.Parse(textBox1.Text);
            this.AnnounceSpeed(speed, 0);
        }
    }
}