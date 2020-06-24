﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirMonitor.Classes {
    class MeasurementItemEntity {
        public MeasurementItemEntity() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public string Values { get; set; }
        public string Indexes { get; set; }
        public string Standards { get; set; }
    }
}
