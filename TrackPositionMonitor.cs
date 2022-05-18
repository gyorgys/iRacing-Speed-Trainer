using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRacingSpeedTrainer
{
    internal class TrackPositionMonitor
    {
        const int MAX_REGION_DATA_SEC = 60 * 5; // 5 minutes
        public struct SingleTelemetryEventArgs
        {
            public TrackMarker Marker;
            public iRacingSDK.Telemetry Tele;
        }

        public struct MultiTelemetryEventArgs
        {
            public TrackMarker Marker;
            public IList<iRacingSDK.Telemetry> Teles;
        }

        const float INVALID_POS = -1;

        private float lastPosition = INVALID_POS;
        private TrackMarker? currentRegion = null;
        private List<iRacingSDK.Telemetry> currentRegionData = new List<iRacingSDK.Telemetry>();
        public IList<TrackMarker> TrackMarkers { get; set; }

        public TrackPositionMonitor(IList<TrackMarker> markers)
        {
            TrackMarkers = markers;
        }

        public void UpdateMarkers(IList<TrackMarker> markers)
        {
            lastPosition = INVALID_POS;
            currentRegion = null;
            currentRegionData = new List<iRacingSDK.Telemetry>();
            TrackMarkers = markers;
        }

        public void ProcessNewData(iRacingSDK.Telemetry tele)
        {
            var previousPosition = this.lastPosition;
            this.lastPosition = tele.LapDist;
            if (previousPosition == INVALID_POS)
            {
                return;
            }
            if (this.currentRegion != null)
            {
                if (this.currentRegion.Intersects(this.lastPosition))
                {
                    if (this.currentRegionData.Count < UserSettings.Default.TelemetryPerSec * MAX_REGION_DATA_SEC)
                    {
                        this.currentRegionData.Add(tele);
                    }
                    return;
                }
                else
                {
                    this.RegionPassed?.Invoke(this, new MultiTelemetryEventArgs { Teles = this.currentRegionData, Marker = this.currentRegion });
                    this.currentRegion = null;
                    this.currentRegionData = new List<iRacingSDK.Telemetry>();
                }
            }
            var marker = this.TrackMarkers.GetMarkerAt(previousPosition, this.lastPosition);
            if (marker == null)
            {
                return;
            }
            if (marker.IsRegion)
            {
                this.currentRegion = marker;
                this.currentRegionData.Add(tele);
                this.RegionEntered?.Invoke(this, new SingleTelemetryEventArgs { Tele = tele, Marker = marker });
            }
            else
            {
                this.PointPassed?.Invoke(this, new SingleTelemetryEventArgs { Tele = tele, Marker = marker });
            }
        }

        public event EventHandler<SingleTelemetryEventArgs>? PointPassed = null;
        public event EventHandler<SingleTelemetryEventArgs>? RegionEntered = null;
        public event EventHandler<MultiTelemetryEventArgs>? RegionPassed = null;
    }
}
