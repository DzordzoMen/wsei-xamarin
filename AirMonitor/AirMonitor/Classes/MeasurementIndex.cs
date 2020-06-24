using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    public class MeasurementIndex {
        public MeasurementIndex() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Value { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Advice { get; set; }
        public string Color { get; set; }
    }
}
