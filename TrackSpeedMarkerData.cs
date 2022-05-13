using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRacingSpeedTrainer
{
    internal class SpeedMarker
    {
        public float Start {  get; set; }
        public float End { get; set; }
    
        public bool IsRegion
        {
            get { return this.Start < this.End; }
        }

        public static SpeedMarker? Deserialize(string line)
        {
            var values = line.Split(' ');
            float startValue = 0;
            float endValue = 0;
            if (values.Length > 0 && Single.TryParse(values[0], out startValue))
            {
                if (values.Length > 1 && Single.TryParse(values[1], out endValue))
                {
                    return new SpeedMarker { End = endValue, Start = startValue };  
                }
                return new SpeedMarker { End = startValue, Start = startValue };
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

    internal class TrackSpeedMarkerData
    {
        private BindingList<SpeedMarker> markers = new BindingList<SpeedMarker>();
        public string TrackName { get; private set; }
        public bool IsDirty { get; private set; }

        public TrackSpeedMarkerData(string trackName)
        {
            this.TrackName = trackName;
            this.markers.ListChanged += Markers_ListChanged;
        }

        private void Markers_ListChanged(object? sender, ListChangedEventArgs e)
        {
            this.IsDirty = true;
        }

        public BindingList<SpeedMarker> Markers { get { return this.markers; } }

        private string GetFilePath()
        {
            return Path.Combine(Program.GetDirPath(), this.TrackName, ".txt");
        }

        public bool Load()
        {
            this.markers.Clear();
            this.IsDirty = false;
            var path = this.GetFilePath();
            if (File.Exists(path))
            {
                using(var file = File.OpenText(path))
                {
                    Trace.TraceInformation(String.Format("Reading file '{0}' for markers", path));
                    while (!file.EndOfStream)
                    {
                        var line = file.ReadLine();
                        if (line != null)
                        {
                            var marker = SpeedMarker.Deserialize(line);
                            if (marker != null)
                            {
                                this.markers.Add(marker);
                            }
                        }
                    }
                    Trace.TraceInformation(String.Format("{0} markers loaded", this.markers.Count));
                }
                return true;
            }
            return false;
        }

        public void Save()
        {
            var path = this.GetFilePath();
            using (var file = File.CreateText(path))
            {
                Trace.TraceInformation(String.Format("Writing markers to file '{0}'", path));
                foreach (var marker in this.markers)
                {
                    file.WriteLine(marker.Serialize());
                }
                Trace.TraceInformation(String.Format("{0} markers written", this.markers.Count));
            }
            this.IsDirty = false;
        }
    }
}
