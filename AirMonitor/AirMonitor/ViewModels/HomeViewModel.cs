using AirMonitor.Classes;
using AirMonitor.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AirMonitor.ViewModels {
    class HomeViewModel: BaseViewModel {
        private INavigation _navigation;
        private Location _userLocation = new Location(50.049683, 19.944544);

        private IEnumerable<Measurement> MeasurmentList;

        private IEnumerable<Installation> Installations;

        public HomeViewModel(INavigation navigation) {
            _navigation = navigation;
            Init();
        }

        private async Task Init() {
            await GetLocation();
            string urlProps = GetQuery(new Dictionary<string, object>() {
                { "lat", _userLocation.Latitude },
                { "lng", _userLocation.Longitude },
                { "maxDistanceKM", 5 },
                { "maxResults", 1 }
            });
            string path = "installations/nearest";
            var installations = await GetNearestInstallations(path, urlProps);
            Installations = installations;
            if (installations != null) {
                var data = await GetInstallationsInfo(installations);
                MeasurmentList = data;
                System.Diagnostics.Debug.WriteLine(data);
            }
        }

        public ICommand GoToDetailsPage => new Command(async () => await _navigation.PushAsync(new DetailsPage()));

        private async Task GetLocation() {
            try {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                _userLocation = await Geolocation.GetLastKnownLocationAsync();
                System.Diagnostics.Debug.WriteLine(_userLocation?.ToString() ?? "no location");
                _userLocation = await Geolocation.GetLocationAsync(request);
                System.Diagnostics.Debug.WriteLine(_userLocation?.ToString() ?? "no location");
            }
            catch (FeatureNotSupportedException fnsEx) {
                // Handle not supported on device exception
                System.Diagnostics.Debug.WriteLine(fnsEx);
            }
            catch (PermissionException pEx) {
                // Handle permission exception
                System.Diagnostics.Debug.WriteLine(pEx);
            }
            catch (Exception ex) {
                // Unable to get location
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private HttpClient SetHttpClient() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(App.AirplyApi);

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            client.DefaultRequestHeaders.Add("apikey", App.AirlyApiKey);

            return client;
        }

        private string MakeUrl(string path, string query) {
            UriBuilder builder = new UriBuilder(App.AirplyApi);
            builder.Path += path;
            builder.Port = -1;
            builder.Query = query;
            string url = builder.ToString();

            return url;
        }

        private string GetQuery(IDictionary<string, object> args) {
            if (args == null) return null;

            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var arg in args) {
                if (arg.Value is double number) {
                    query[arg.Key] = number.ToString(CultureInfo.InvariantCulture);
                }
                else {
                    query[arg.Key] = arg.Value?.ToString();
                }
            }

            return query.ToString();
        }

        public async Task<IEnumerable<Installation>> GetNearestInstallations(string path, string urlProps) {
            HttpClient client = SetHttpClient();
            // i hate myself and this url :)
            var response = await client.GetAsync(MakeUrl(path, urlProps));

            if (response.Headers.TryGetValues("X-RateLimit-Remaining-day", out var limitLeft)) {
                System.Diagnostics.Debug.WriteLine($"Pozostało w tym dniu {limitLeft} zapytań do zrobienia");
            }

            if ((int)response.StatusCode == 200) {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Installation>>(content);
                System.Diagnostics.Debug.WriteLine(result);
                return result;
            } else {
                System.Diagnostics.Debug.WriteLine("Pomocy");
            }
            return null;

        }

        public async Task<IEnumerable<Measurement>> GetInstallationsInfo(IEnumerable<Installation> installations) {
            HttpClient client = SetHttpClient();
            var measurements = new List<Measurement>();
            foreach (var installation in installations) {
                string urlProps = GetQuery(new Dictionary<string, object>() {
                    { "installationId", installation.Id },
                });
                var url = MakeUrl("measurements/installation", urlProps);
                var response = await client.GetAsync(url);
                if ((int)response.StatusCode == 200) {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Measurement>(content);
                    measurements.Add(result);
                    System.Diagnostics.Debug.WriteLine(result);
                }
                else {
                    System.Diagnostics.Debug.WriteLine("I once again asking for help");
                }
            }
            return measurements;
        }
    }
}
