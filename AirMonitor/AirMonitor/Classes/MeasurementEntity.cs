using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    class MeasurementEntity {
        public MeasurementEntity() { }
        public MeasurementEntity(Measurement measurement) {
            Current = JsonConvert.SerializeObject(measurement.Current);
            History = JsonConvert.SerializeObject(measurement.History);
            Forecast = JsonConvert.SerializeObject(measurement.Forecast);
            Installation = JsonConvert.SerializeObject(measurement.Installation);
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Current { get; set; }
        public string History { get; set; }
        public string Forecast { get; set; }
        public string Installation { get; set; }
    }
}
