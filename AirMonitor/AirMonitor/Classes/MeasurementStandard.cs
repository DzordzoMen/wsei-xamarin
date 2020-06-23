using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    class MeasurementStandard {
        public string Name { get; set; }
        public string Pollutant { get; set; }
        public int Limit { get; set; }
        public Double Percent { get; set; }
    }
}
