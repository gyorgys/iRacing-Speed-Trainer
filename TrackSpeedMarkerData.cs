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
        public float Start { get; private set; } = -1;
        public float End { get; private set; } = -1;

        protected TrackMarker() {}

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

        public bool IsInvalid { 
            get
            {
                return this.Start == -1;
            }        
        }

        public bool Intersects(float position)
        {
            return this.Intersects(new TrackMarker { Start = position, End = position });
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
            if (values.Length > 0 && Single.TryParse(values[0], out startValue))
            {
                if (values.Length > 1 && Single.TryParse(values[1], out endValue))
                {
                    return new TrackMarker { End = endValue, Start = startValue };
                }
                return new TrackMarker { End = startValue, Start = startValue };
            }
            return null;
        }

        public string Serialize()
        {
            if (this.IsRegion)
            {
                return String.Format("{0} {1}", this.Start, this.End);
            }
            else
            {
                return String.Format("{0}", this.Start);
            }
        }

        override public string ToString()
        {
            return this.Serialize();
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
            this.IsDirty = true;
            this.MarkersChanged?.Invoke(this, this.Markers);
            return true;
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
