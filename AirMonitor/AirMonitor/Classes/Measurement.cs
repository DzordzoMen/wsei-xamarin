using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    public class Measurement {
        public Measurement() { }

        public MeasurementItem Current { get; set; }
        public MeasurementItem[] History { get; set; }
        public MeasurementItem[] Forecast { get; set; }
        public Installation Installation { get; set; }
    }
}
