using System;
using System.Net.Http;
using AirMonitor.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirMonitor {
    public partial class App : Application {
        public static string AirlyApiKey = "e15E2TlDGElToTrs86heUlOU1WhUV1SV";
        public static string AirplyApi = "https://airapi.airly.eu/v2/";

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new AirMonitorNavigationPage());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
