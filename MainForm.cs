namespace IRacingSpeedTrainer
{
    using iRacingSDK;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Speech.Synthesis;

    public partial class MainForm : Form
    {
        private enum State
        {
            None = 0,
            Stopped,
            Starting,
            Connected,
            Disconnected,
        }

        private State state = State.None;
        private iRacingEvents? iRacing = null;
        private string? currentTrack = null;
        private float? currentDistance = null;
        private BindingList<float> points = new BindingList<float>();
        private SpeechSynthesizer synth = new SpeechSynthesizer();

        public MainForm()
        {
            InitializeComponent();
            this.pointsListBox.DataSource = this.points;
            setState(State.Stopped);
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            synth.Rate = 2;
        }

        private void setState(State newState)
        {
            if (newState == this.state)
            {
                return;
            }
            Trace.TraceInformation(String.Format("State changing to {0}", newState.ToString()));
            this.speedLabel.Text = "";
            switch(newState)
            {
                case State.Stopped:
                    this.startStopButton.Text = "Start";
                    this.startStopButton.Enabled = true;
                    this.toolStripStatusLabel.Text = "Stopped";
                    this.toolStripDataLabel.Text = "";
                    break;
                case State.Starting:
                    this.startStopButton.Text = "Starting";
                    this.startStopButton.Enabled = false;
                    this.toolStripStatusLabel.Text = "Starting";
                    break;
                case State.Disconnected:
                    this.startStopButton.Text = "Stop";
                    this.startStopButton.Enabled = true;
                    this.toolStripStatusLabel.Text = "Disconnected";
                    break;
                case State.Connected:
                    this.startStopButton.Text = "Stop";
                    this.startStopButton.Enabled = true;
                    this.toolStripStatusLabel.Text = "Connected";
                    break;
            }
            this.state = newState;
        }

        private void startListening()
        {
            this.setState(State.Starting);
            this.currentTrack = null;
            try
            {
                if (this.iRacing == null)
                {
                    this.iRacing = new iRacingEvents(1000 / 60);
                    this.iRacing.Connected += IRacing_Connected;
                    this.iRacing.Disconnected += IRacing_Disconnected;
                    this.iRacing.NewData += IRacing_NewData;
                    this.iRacing.NewSessionData += IRacing_NewSessionData;
                }
                //this.iRacing.StopListening();
                this.setState(State.Disconnected);
                this.iRacing.StartListening();
            } catch (Exception ex)
            {
                this.iRacing = null;
                MessageBox.Show(this, ex.Message, "Error connecting to iRacing",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.setState(State.Stopped);
            }
        }

        private void IRacing_NewSessionData(DataSample obj)
        {
            var data = obj.LastSample?.SessionData;
            if (data != null)
            { 
                this.currentTrack = data.WeekendInfo.TrackName; 
            }
            else
            {
                this.currentTrack = null;
            }
        }

        private void IRacing_NewData(DataSample obj)
        {
            var sample = obj.LastSample;
            if (sample != null)
            {
                string track = sample.SessionData.WeekendInfo.TrackName;
                long carIndex = sample.SessionData.DriverInfo.DriverCarIdx;
                var speed = Math.Round(sample.Telemetry.Speed * 2.23694, 1);
                float previousDistance = this.currentDistance ?? -1;
                this.currentDistance = sample.Telemetry.LapDist;
                var distancePct = sample.Telemetry.LapDistPct * 100.0;
                this.toolStripDataLabel.Text = String.Format("Speed: {0} @{1:0.0}({2:0.00}%) Track: {3}", speed, this.currentDistance, distancePct, track);
                if (previousDistance >= 0)
                {
                    foreach (var point in this.points)
                    {
                        if (previousDistance < point && this.currentDistance >= point)
                        {
                            this.announceSpeed(speed, point);
                        }
                    }
                }
            } 
            else
            {
                this.toolStripDataLabel.Text = "no data";
            }
        }

        private void announceSpeed(double speed, float point)
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

        private void stopListening()
        {
            if (this.iRacing != null)
            {
                this.iRacing.StopListening();
            }
            this.setState(State.Stopped);
        }

        private void IRacing_Disconnected()
        {
            this.setState(State.Disconnected);
        }

        private void IRacing_Connected()
        {
            this.setState(State.Connected);
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if(this.state == State.Stopped)
            {
                this.startListening();
            } else
            {
                this.stopListening();
            }
        }

        private void addPosButton_Click(object sender, EventArgs e)
        {
            var distance = this.currentDistance;
            if (distance != null)
            {
                this.points.Add(distance ?? 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double speed = Double.Parse(textBox1.Text);
            this.announceSpeed(speed, 0);
        }
    }
}