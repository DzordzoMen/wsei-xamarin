using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirMonitor.Classes {
    public class MeasurementItemEntity {
        public MeasurementItemEntity() { }

        public MeasurementItemEntity(MeasurementItem measurementItem) {
            if (measurementItem == null) return;

            FromDateTime = measurementItem.FromDateTime;
            TillDateTime = measurementItem.TillDateTime;

            Values = JsonConvert.SerializeObject(measurementItem.Values?.Select(measurementInfo => measurementInfo.Id));
            Indexes = JsonConvert.SerializeObject(measurementItem.Indexes?.Select(measurementInfo => measurementInfo.Id));
            Standards = JsonConvert.SerializeObject(measurementItem.Standards?.Select(measurementInfo => measurementInfo.Id));
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public string Values { get; set; }
        public string Indexes { get; set; }
        public string Standards { get; set; }
    }
}
