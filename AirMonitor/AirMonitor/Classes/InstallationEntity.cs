﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AirMonitor.Classes {
    class InstallationEntity {
        public InstallationEntity() { }

        public string Id { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public Double Elevation { get; set; }
        public Boolean Airly { get; set; }
        public string Sponsor { get; set; }

        public InstallationEntity(Installation installation) {
            Id = installation.Id;
            Location = JsonConvert.SerializeObject(installation.Location);
            Address = JsonConvert.SerializeObject(installation.Address);
            Elevation = installation.Elevation;
            Airly = installation.Airly;
            Sponsor = JsonConvert.SerializeObject(installation.Sponsor);
        }
    }
}
