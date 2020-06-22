using AirMonitor.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AirMonitor.ViewModels
{
    class HomeViewModel {
        private INavigation _navigation;
        public HomeViewModel(INavigation navigation) {
            _navigation = navigation;
        }

        public ICommand GoToDetailsPage => new Command(async () => await _navigation.PushAsync(new DetailsPage()));
    }
}
