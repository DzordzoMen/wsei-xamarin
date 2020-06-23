using AirMonitor.Classes;
using AirMonitor.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirMonitor.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {

        public HomePage() {
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);
        }

        void Select(object sender, ItemTappedEventArgs e) {
            var tt = (HomeViewModel)BindingContext;
            tt.GoToDetailsPage.Execute(e.Item as Measurement);
        }
    }
}