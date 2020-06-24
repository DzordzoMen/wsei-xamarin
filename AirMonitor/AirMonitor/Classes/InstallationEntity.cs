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
    }
}
