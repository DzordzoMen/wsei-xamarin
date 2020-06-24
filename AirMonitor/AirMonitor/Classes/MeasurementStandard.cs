using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    public class MeasurementStandard {
        public MeasurementStandard() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pollutant { get; set; }
        public Double Limit { get; set; }
        public Double Percent { get; set; }
        public string Averaging { get; set; }
    }
}
