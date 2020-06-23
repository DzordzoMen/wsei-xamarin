using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AirMonitor.ViewModels
{
    class DetailsViewModel : BaseViewModel {
        private int _caqiValue = 57;
        public int CaqiValue {
            set {
                if (_caqiValue == value) return;

                _caqiValue = value;
                ExecutePropertyChanged("CaqiValue");
            }
            get {
                return _caqiValue;
            }
        }

        private string _caqiTitle = "Świetna jakość!";

        public string CaqiTitle {
            set {
                if (_caqiTitle == value) return;

                _caqiTitle = value;
                ExecutePropertyChanged("CaqiTitle");
            }
            get {
                return _caqiTitle;
            }
        }

        private string _caqiDescription = "Możesz bezpiecznie wyjść z domu bez swojej maski anty-smogowej i nie bać się o swoje zdrowie.";

        public string CaqiDescription {
            set {
                if (_caqiDescription == value) return;

                _caqiDescription = value;
                ExecutePropertyChanged("CaqiDescription");
            }

            get {
                return _caqiDescription;
            }
        }

        private int _pm25Value = 34;

        public int Pm25Value {
            set {
                if (_pm25Value == value) return;

                _pm25Value = value;
                ExecutePropertyChanged("Pm25Value");
            }

            get {
                return _pm25Value;
            }
        }

        private int _pm25Percent = 137;

        public int Pm25Percent {
            set {
                if (_pm25Percent == value) return;

                _pm25Percent = value;
                ExecutePropertyChanged("Pm25Percent");
            }

            get {
                return _pm25Percent;
            }
        }

        private int _pm10Value = 67;

        public int Pm10Value {
            set {
                if (_pm10Value == value) return;

                _pm10Value = value;
                ExecutePropertyChanged("Pm10Value");
            }

            get {
                return _pm10Value;
            }
        }

        private int _pm10Percent = 135;

        public int Pm10Percent {
            set {
                if (_pm10Percent == value) return;

                _pm10Percent = value;
                ExecutePropertyChanged("Pm10Percent");
            }

            get {
                return _pm10Percent;
            }
        }

        private Double _wetnessValue = 0.95;

        public Double WetnessValue {
            set {
                if (_wetnessValue == value) return;

                _wetnessValue = value;
                ExecutePropertyChanged("WetnessValue");
            }

            get {
                return _wetnessValue;
            }
        }

        private int _pressureValue = 1026;

        public int PressureValue {
            set {
                if (_pressureValue == value) return;

                _pressureValue = value;
                ExecutePropertyChanged("Pm10Value");
            }

            get {
                return _pressureValue;
            }
        }

        public DetailsViewModel() { }

    }
}
