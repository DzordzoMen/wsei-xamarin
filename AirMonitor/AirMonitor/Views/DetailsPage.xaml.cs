using AirMonitor.Classes;
using AirMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AirMonitor.Views {
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DetailsPage : ContentPage {
        public DetailsPage(Measurement measurement) {
            InitializeComponent();
            BindingContext = new DetailsViewModel(measurement);
        }

        private void Help_Clicked(object sender, EventArgs e) {
            DisplayAlert("Co to jest CAQI?", "Lorem ipsum.", "Zamknij");
        }
    }
}
