using Newtonsoft.Json;
using System;
using Xamarin.Essentials;

namespace AirMonitor.Classes {
    public class Installation {
        public Installation(InstallationEntity installationEntity) {
            if (installationEntity == null) return;

            Id = installationEntity.Id;
            Location = JsonConvert.DeserializeObject<Location>(installationEntity.Location);
            Address = JsonConvert.DeserializeObject<Address>(installationEntity.Address);
            Elevation = installationEntity.Elevation;
            Airly = installationEntity.Airly;
        }

        public string Id { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; }
        public Double Elevation { get; set; }
        public Boolean Airly { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
