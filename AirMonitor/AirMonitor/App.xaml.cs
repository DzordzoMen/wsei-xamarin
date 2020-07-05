using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AirMonitor.Classes;
using AirMonitor.Views;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirMonitor {
    public partial class App : Application {
        public static string AirlyApiKey;
        public static string AirplyApi;

        public static DatabaseHelper DatabaseHelper;

        public App() {
            InitializeComponent();
            LoadConfig();
            DatabaseHelper = new DatabaseHelper();
            MainPage = new NavigationPage(new AirMonitorNavigationPage());
        }

        protected override void OnStart() {
            if (DatabaseHelper == null) DatabaseHelper = new DatabaseHelper();
        }

        protected override void OnSleep() {
            DatabaseHelper.Dispose();
            DatabaseHelper = null;
        }

        protected override void OnResume() {
            if (DatabaseHelper == null) DatabaseHelper = new DatabaseHelper();
        }

        private async Task LoadConfig() {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames();
            var config = resourceName.FirstOrDefault(name => name.Contains("config.json"));

            using (Stream stream = assembly.GetManifestResourceStream(config))
            using (StreamReader reader = new StreamReader(stream)) {
                var result = await reader.ReadToEndAsync();
                var parsedResult = JObject.Parse(result);
                AirlyApiKey = parsedResult["ApiKey"].ToString();
                AirplyApi = parsedResult["ApiURL"].ToString();
            }
        }
    }
}
