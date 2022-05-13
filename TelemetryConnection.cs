using iRacingSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRacingSpeedTrainer
{
    internal class TrackInfo
    {
        public string Name { get; init; } = "";
        public string DisplayName { get; init; } = "";
    }

    internal class TelemetryConnection : IDisposable
    {
        public enum ConnectionStates
        {
            None = 0,
            Error,
            Stopped,
            Listening,
            Connected,
        }

        public enum CarStates
        {
            None = 0,
            InMenus,
            InPits,
            OnTrack,
        }

        private iRacingEvents? iRacing = null;
        
        private ConnectionStates connectionState = ConnectionStates.Stopped;
        public ConnectionStates ConnectionState { 
            get { return this.connectionState;  } 
            private set
            {
                bool changed = (this.connectionState != value);
                this.connectionState = value;
                if (changed)
                {
                    this.ConnectionStateChanged?.Invoke(this, value);
                }
            }
        }

        private CarStates carState = CarStates.None;
        public CarStates CarState
        {
            get { return this.carState; }
            private set
            {
                bool changed = (this.carState != value);
                this.carState = value;
                if (changed)
                {
                    this.CarStateChanged?.Invoke(this, value);
                }
            }
        }

        private TrackInfo? currentTrack = null;
        public TrackInfo? CurrentTrack
        {
            get { return this.currentTrack; }
            private set
            {
                bool changed = (this.currentTrack?.Name != value?.Name);
                this.currentTrack = value;
                if (changed)
                {
                    this.CurrentTrackChanged?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<ConnectionStates>? ConnectionStateChanged;
        public event EventHandler<CarStates>? CarStateChanged;
        public event EventHandler<TrackInfo?>? CurrentTrackChanged;
        public event EventHandler<iRacingSDK.Telemetry>? NewTelemetryData;

        public bool IsAcquiringTelemetry {  get
            {
                return this.ConnectionState == ConnectionStates.Connected && 
                    this.CarState == CarStates.OnTrack;
            } 
        }

        public bool Start()
        {
            if (this.ConnectionState != ConnectionStates.Stopped)
            {
                return false;
            }
            try
            {
                if (this.iRacing == null)
                {
                    this.iRacing = new iRacingEvents(1000 / UserSettings.Default.TelemetryPerSec);
                    this.iRacing.Connected += IRacing_Connected;
                    this.iRacing.Disconnected += IRacing_Disconnected;
                    this.iRacing.NewData += IRacing_NewData;
                    this.iRacing.NewSessionData += IRacing_NewSessionData;
                }
                Trace.TraceInformation("Connection initializing, {0} Hz", UserSettings.Default.TelemetryPerSec);
                this.iRacing.StartListening();
                this.ConnectionState = ConnectionStates.Listening;
            }
            catch (Exception ex)
            {
                Trace.TraceWarning(String.Format("Connection to iRacing failed: {0}", ex.Message));
                this.iRacing = null;
                this.ConnectionState = ConnectionStates.Error;
                return false;
            }
            return true;
        }

        public bool Stop()
        {
            if (
                this.ConnectionState != ConnectionStates.Listening &&
                this.ConnectionState != ConnectionStates.Connected
               )
            {
                return false;
            }
            try
            {
                this.iRacing?.StopListening();
                this.CurrentTrack = null;
                this.CarState = CarStates.None;
                this.ConnectionState = ConnectionStates.Stopped;
            }
            catch (Exception ex)
            {
                Trace.TraceWarning(String.Format("Disconnection from iRacing failed: {0}", ex.Message));
                this.iRacing?.Dispose();
                this.iRacing = null;
                this.ConnectionState = ConnectionStates.Error;
                return false;
            }
            return true;
        }

        private void IRacing_NewSessionData(DataSample obj)
        {
            var data = obj.SessionData;
            if (data != null)
            {
                Trace.TraceInformation(String.Format("New session on {0}", data.WeekendInfo.TrackName));
                this.CurrentTrack = new TrackInfo
                {
                    Name = data.WeekendInfo.TrackName,
                    DisplayName = String.Format(
                            "{0} - {1}",
                            data.WeekendInfo.TrackDisplayShortName,
                            data.WeekendInfo.TrackConfigName
                        ),
                };
            }
            else
            {
                Trace.TraceWarning("New session with no track");
                this.CurrentTrack = null;
            }
        }

        private void IRacing_NewData(DataSample obj)
        {
            var sample = obj.LastSample;
            if (sample != null && sample.IsConnected)
            {
                var tele = sample.Telemetry;
                if (tele == null)
                {
                    this.CarState = CarStates.None;
                    return;
                }
                if (!tele.IsOnTrack)
                {
                    this.CarState = CarStates.InMenus;
                    return;
                }
                if (tele.OnPitRoad)
                {
                    this.CarState = CarStates.InPits;
                    return;
                }
                this.CarState = CarStates.OnTrack;
                this.NewTelemetryData?.Invoke(this, tele);
            }
            else
            {
                this.CarState = CarStates.None;
            }
        }

        private void IRacing_Disconnected()
        {
            Trace.TraceInformation("Connection disconnected");
            this.CurrentTrack = null;
            this.CarState = CarStates.None;
            this.ConnectionState = ConnectionStates.Listening;
        }

        private void IRacing_Connected()
        {
            Trace.TraceInformation("Connection success");
            this.ConnectionState = ConnectionStates.Connected;
        }

        public void Dispose()
        {
            try
            {
                ((IDisposable?)iRacing)?.Dispose();
            } catch 
            { }
        }
    }
}
