using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    class MeasurementEntity {
        public MeasurementEntity() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Current { get; set; }
        public string History { get; set; }
        public string Forecast { get; set; }
        public string Installation { get; set; }
    }
}
