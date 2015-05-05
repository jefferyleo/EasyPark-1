using System.Collections.Generic;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Services;

namespace EasyPark.Core.ViewModels
{
    public class HomeViewModel
        : MvxViewModel
    {

        private readonly IMvxGeoLocationWatcher _watcher;

        public HomeViewModel(ICloudService _service, IMvxGeoLocationWatcher watcher)
        {
            if (_service.CurrentUser == null)
                ShowViewModel<LoginViewModel>();
            else
            {
                _watcher = watcher;
                _watcher.Start(new MvxGeoLocationOptions() { EnableHighAccuracy = true }, OnLocation, OnError);
            }
        }

        private void OnLocation(MvxGeoLocation location)
        {
            Mvx.Warning("Test Warning");
            Mvx.Error("Test Error");
            Lat = location.Coordinates.Latitude;
            Lng = location.Coordinates.Longitude;
        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Seen location error {0}", error.Code);
        }

        private double _lat;
        public double Lat
        {
            get { return _lat; }
            set { _lat = value; RaisePropertyChanged(() => Lat); }
        }

        private double _lng;
        public double Lng
        {
            get { return _lng; }
            set { _lng = value; RaisePropertyChanged(() => Lng); }
        }

        private string _searchKey;
        public string SearchKey
        {
            get { return _searchKey; }
            set { _searchKey = value; RaisePropertyChanged(() => SearchKey); }
        }

        private List<object> _results;
        public List<object> Results
        {
            get { return _results; }
            set { _results = value; RaisePropertyChanged(() => Results); }
        }
    }
}
