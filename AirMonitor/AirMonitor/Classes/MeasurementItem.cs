using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    public class MeasurementItem {
        public MeasurementItem() { }

        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public MeasurementValue[] Values { get; set; }
        public MeasurementIndex[] Indexes { get; set; }
        public MeasurementStandard[] Standards { get; set; }
    }
}
