using System;
using System.Collections.Generic;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Models;
using EasyPark.Core.Services;
using EasyPark.Timer;

namespace EasyPark.Core.ViewModels
{
    public class HomeViewModel
        : MvxViewModel
    {
        private readonly object _lockObject = new object();
        private PCLTimer _timer;
        private readonly ICloudService _cloudService;
        private readonly IPlaceService _placeService;
        private readonly IMvxLocationWatcher _locationWatcher;

        public HomeViewModel(ICloudService cloudService, IPlaceService placeService, IMvxLocationWatcher locationWatcher)
        {
            _cloudService = cloudService;
            _placeService = placeService;
            _locationWatcher = locationWatcher;
            _locationWatcher.Start(new MvxLocationOptions(), OnLocation, OnError);
            StatusText = "Easy Park";
            IsLoading = false;
        }

        private string _statusText;
        public string StatusText
        {
            get { return _statusText; }
            set { _statusText = value; RaisePropertyChanged(() => StatusText); }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        private int _currentPoint;
        public int CurrentPoint
        {
            get { return _currentPoint; }
            set { _currentPoint = value; RaisePropertyChanged(() => CurrentPoint); }
        }

        private string _ratio;
        public string Ratio
        {
            get { return _ratio; }
            set { _ratio = value; RaisePropertyChanged(() => Ratio); }
        }

        private List<Car> _cars;
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; RaisePropertyChanged(() => Cars); }
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
            set { _searchKey = value; RaisePropertyChanged(() => SearchKey); ScheduleUpdate(); }
        }

        private List<PlaceSearchItem> _results;
        public List<PlaceSearchItem> Results
        {
            get { return _results; }
            set { _results = value; RaisePropertyChanged(() => Results); }
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

        private void ScheduleUpdate()
        {
            if(SearchKey != "")
                lock (_lockObject)
                {
                    if (_timer == null)
                        _timer = new PCLTimer(OnTimerTick, null, TimeSpan.FromSeconds(1.0), TimeSpan.Zero);
                    else
                        _timer.Change(TimeSpan.FromSeconds(1.0), TimeSpan.Zero);
                }
        }

        private void OnTimerTick(object state)
        {
            lock (_lockObject)
            {
                _timer.Dispose();
                _timer = null;
            }
            Update();
        }

        private void Update()
        {
            StatusText = "Searching...";
            IsLoading = true;
            _placeService.StartSearchAsync(
                SearchKey,
                Lat,
                Lng,
                result =>
                {
                    StatusText = "Easy Park";
                    IsLoading = false;
                    Results = result.results;
                },
                error =>
                {
                    StatusText = "Easy Park";
                    IsLoading = false;
                }
            );
        }

        MvxCommand _addCarCommand;
        public System.Windows.Input.ICommand AddCarCommand
        {
            get
            {
                _addCarCommand = _addCarCommand ?? new MvxCommand(DoAddCarCommand);
                return _addCarCommand;
            }
        }

        private void DoAddCarCommand()
        {
            ShowViewModel<CarViewModel>();
        }
    }
}
