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
        private float currentDistancePct = -1;
        private float currentSpeedMps = 0;
        private TrackData? trackData = null;
        private string fullTrackName = "";
        private SpeechSynthesizer synth = new SpeechSynthesizer();
        private GameControllers controllers = new GameControllers();
        private System.Windows.Forms.Timer inputPollTimer = new System.Windows.Forms.Timer();

        public MainForm()
        {
            InitializeComponent();
            UpdateConnectionState();
            UpdateCarState();
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            synth.Rate = 2;
            this.controllers.ControllersChanged += Controllers_ControllersChanged;
        }

        private void Controllers_ControllersChanged(object? sender, EventArgs e)
        {
            this.gameControllersList.DataSource = null;
            this.gameControllersList.DataSource = this.controllers.ControllerData;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.controllers.Dispose();
            if (this.trackData?.IsDirty ?? false)
            {
                this.trackData?.Save();
            }
            this.inputPollTimer.Stop();
            this.iRacing?.Dispose();
            this.iRacing = null;
            base.OnFormClosing(e);
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
            this.currentSpeedMps = tele.Speed;
            var speed = Math.Round(this.currentSpeedMps * 2.23694, 1);
            float previousDistance = this.currentDistance;
            this.currentDistance = tele.LapDist;
            this.currentDistancePct = tele.LapDistPct * 100.0f;
            this.dataLabel.Text = String.Format("Speed: {0} @{1:0.0}({2:0.00}%)", speed, this.currentDistance, this.currentDistancePct);
            if (previousDistance >= 0 && this.trackData != null)
            {
                foreach (var marker in this.trackData.Markers)
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
                this.addPosButton.Enabled = false;
                this.pointsListBox.DataSource = null;
            }
            if (track != null)
            {
                this.trackData = new TrackData(track.Name);
                this.trackData.MarkersChanged += TrackData_MarkersChanged;
                this.pointsListBox.DataSource = null;
                this.trackData.Load();
                this.addPosButton.Enabled = true;
            }
            this.UpdateStatusLabel();
        }

        private void TrackData_MarkersChanged(object? sender, IList<TrackMarker> markers)
        {
            this.pointsListBox.DataSource = new List<TrackMarker>(markers);
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
                this.trackData?.AddMarker(new TrackMarker(distance));
                //this.pointsListBox.DataSource = this.trackData?.Markers;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double speed = Double.Parse(textBox1.Text);
            this.AnnounceSpeed(speed, 0);
        }

        private void InputPollTimer_Tick(object? sender, EventArgs e)
        {
           this.label1.Text = String.Join(" + ", controllers.GetInputs());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.controllers.ScanAndAquire(this.Handle);
            this.gameControllersList.DataSource = this.controllers.ControllerData;
            this.inputPollTimer.Interval = 1000 / 30;
            this.inputPollTimer.Start();
            this.inputPollTimer.Tick += InputPollTimer_Tick;
        }
    }
}