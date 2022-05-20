using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRacingSpeedTrainer
{
    internal class TrackMarker
    {
        const float MAX_TRACK_POS = 1000000.0f;

        public static float DistanceConversion { get; set; } = 1f;
        public static string DistanceLabel { get; set; } = "m";

        public float Start { get; private set; } = -1;
        public float End { get; private set; } = -1;

        private bool enabled = true;
        public bool Enabled { 
            get => enabled;
            set
            {
                if (value != this.enabled) 
                { 
                    this.enabled = value;
                    this.Changed?.Invoke(this, new EventArgs());
                }
            } 
        }

        public event EventHandler? Changed;

        protected TrackMarker() { }

        public TrackMarker(float position)
        {
            if (position < 0)
                throw new ArgumentOutOfRangeException(nameof(position));
            Start = position;
            End = position;
        }

        public TrackMarker(float start, float end)
        {
            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));
            if (end < 0)
                throw new ArgumentOutOfRangeException(nameof(end));
            Start = start;
            End = end;
        }

        public static readonly TrackMarker InvalidMarker = new TrackMarker();

        public bool IsRegion
        {
            get { return this.Start != this.End; }
        }

        public bool IsInvalid
        {
            get
            {
                return this.Start == -1;
            }
        }

        public bool Intersects(float position)
        {
            return this.Intersects(new TrackMarker { Start = position, End = position });
        }
        public bool Intersects(float startPosition, float endPosition)
        {
            return this.Intersects(new TrackMarker { Start = startPosition, End = endPosition });
        }

        public bool Intersects(TrackMarker marker)
        {
            return this.Start < marker.Start ? TrackMarker.Intersects(this, marker) : TrackMarker.Intersects(marker, this);
        }

        private static bool Intersects(TrackMarker left, TrackMarker right)
        {
            float leftEnd = left.End >= left.Start ? left.End : left.End + MAX_TRACK_POS;
            float rightEnd = right.End >= right.Start ? right.End : right.End + MAX_TRACK_POS;
            if (left.IsRegion)
            {
                return left.End > right.Start;
            }
            return left.Start == right.Start;
        }

        public static TrackMarker? Deserialize(string line)
        {
            var values = line.Split(' ');
            float startValue = 0;
            float endValue = 0;
            bool enabled = true;
            if (values.Length > 0 && Single.TryParse(values[0], out startValue))
            {
                if (startValue < 0)
                {
                    enabled = false;
                    startValue = -startValue;
                }
                if (values.Length > 1 && Single.TryParse(values[1], out endValue))
                {
                    return new TrackMarker { End = endValue, Start = startValue, Enabled = enabled };
                }
                return new TrackMarker { End = startValue, Start = startValue, Enabled = enabled };
            }
            return null;
        }

        public string Serialize()
        {
            string prefix = this.Enabled ? "" : "-";
            if (this.IsRegion)
            {
                return String.Format("{2}{0} {1}", this.Start, this.End, prefix);
            }
            else
            {
                return String.Format("{1}{0}", this.Start, prefix);
            }
        }

        override public string ToString()
        {
            if (this.IsRegion)
            {
                return String.Format(
                    "{0:0.0} {2} - {1:0.0} {2}",
                    this.Start * DistanceConversion,
                    this.End * DistanceConversion,
                    DistanceLabel);
            }
            else
            {
                return String.Format("{0:0.0} {1}", this.Start * DistanceConversion, DistanceLabel);
            }
        }
    }

    internal static class TrackMarkerExtensions
    {
        public static TrackMarker? GetMarkerAt(this IEnumerable<TrackMarker> markers, float position)
        {
            var marker = markers.FirstOrDefault(
                m => m.Intersects(position),
               TrackMarker.InvalidMarker);
            return marker.IsInvalid ? null : marker;
        }

        public static TrackMarker? GetMarkerAt(this IEnumerable<TrackMarker> markers, float startPosition, float endPosition)
        {
            var marker = markers.FirstOrDefault(
                m => m.Intersects(startPosition, endPosition ),
               TrackMarker.InvalidMarker);
            return marker.IsInvalid ? null : marker;
        }
    }

    internal class TrackData
    {
        private SortedList<float, TrackMarker> markers = new SortedList<float, TrackMarker>();
        public string TrackName { get; private set; }
        public bool IsDirty { get; private set; }

        public TrackData(string trackName)
        {
            this.TrackName = trackName;
        }

        public IList<TrackMarker> Markers
        {
            get
            {
                return (IList<TrackMarker>)this.markers.Values;
            }
        }

        public event EventHandler<IList<TrackMarker>>? MarkersChanged = null;

        private string GetFilePath()
        {
            return Path.Combine(Program.GetDirPath(), this.TrackName + ".txt");
        }

        public bool Load()
        {
            this.markers.Clear();
            this.IsDirty = false;
            var path = this.GetFilePath();
            if (File.Exists(path))
            {
                using (var file = File.OpenText(path))
                {
                    Trace.TraceInformation(String.Format("Reading file '{0}' for markers", path));
                    while (!file.EndOfStream)
                    {
                        var line = file.ReadLine();
                        if (line != null)
                        {
                            var marker = TrackMarker.Deserialize(line);
                            if (marker != null)
                            {
                                this.markers.Add(marker.Start, marker);
                                marker.Changed += Marker_Changed;
                            }
                        }
                    }
                    Trace.TraceInformation(String.Format("{0} markers loaded", this.markers.Count));
                }
                this.MarkersChanged?.Invoke(this, this.Markers);
                return true;
            }
            return false;
        }

         public bool AddMarker(TrackMarker newMarker)
        {
            if (this.markers.Any(m => m.Value.Intersects(newMarker)))
            {
                Trace.TraceInformation(String.Format("Not adding marker {0} as it intersects existing one", newMarker.ToString()));
                return false;
            }
            this.markers.Add(newMarker.Start, newMarker);
            newMarker.Changed += Marker_Changed;
            this.IsDirty = true;
            this.MarkersChanged?.Invoke(this, this.Markers);
            return true;
        }

        private void Marker_Changed(object? sender, EventArgs e)
        {
            this.IsDirty = true;
        }

        public void DeleteMarkerAt(float position)
        {
            var marker = this.markers.Values.GetMarkerAt(position);
            if (marker != null)
            {
                this.markers.Remove(marker.Start);
                this.IsDirty = true;
                this.MarkersChanged?.Invoke(this, this.Markers);
            }
        }

        public void Save()
        {
            var path = this.GetFilePath();
            using (var file = File.CreateText(path))
            {
                Trace.TraceInformation(String.Format("Writing markers to file '{0}'", path));
                foreach (var marker in this.Markers)
                {
                    file.WriteLine(marker.Serialize());
                }
                Trace.TraceInformation(String.Format("{0} markers written", this.markers.Count));
            }
            this.IsDirty = false;
        }
    }
}
