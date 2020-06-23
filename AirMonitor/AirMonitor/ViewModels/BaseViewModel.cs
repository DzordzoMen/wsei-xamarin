using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AirMonitor.ViewModels {
    class BaseViewModel: INotifyPropertyChanged {

        public BaseViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ExecutePropertyChanged(string propName) {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
