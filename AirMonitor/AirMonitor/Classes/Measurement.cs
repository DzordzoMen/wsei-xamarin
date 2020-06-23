using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    class Measurement {
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public MeasurementValue Values { get; set; }
        public MeasurementIndex Indexes { get; set; }
        public MeasurementStandard Standards { get; set; }
    }
}
