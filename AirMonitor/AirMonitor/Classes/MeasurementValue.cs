using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    public class MeasurementValue {
        public MeasurementValue() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Value { get; set; }
    }
}
