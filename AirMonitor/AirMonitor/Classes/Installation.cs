using System;
using Xamarin.Essentials;

namespace AirMonitor.Classes {
    class Installation {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; }
        public Double Elevation { get; set; }
        public Boolean Airly { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
