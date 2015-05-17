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
            if(!_locationWatcher.Started)
                _locationWatcher.Start(new MvxLocationOptions(), OnLocation, OnError);
            Update();
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

        private List<Car> _cars;
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; RaisePropertyChanged(() => Cars); }
        }

        private int _parkPoint;
        public int ParkPoint
        {
            get { return _parkPoint; }
            set { _parkPoint = value; RaisePropertyChanged(() => ParkPoint); }
        }

        private int _successDealCount;
        public int SuccessDealCount
        {
            get { return _successDealCount; }
            set { _successDealCount = value; RaisePropertyChanged(() => SuccessDealCount); }
        }

        private int _failDealCount;
        public int FailDealCount
        {
            get { return _failDealCount; }
            set { _failDealCount = value; RaisePropertyChanged(() => FailDealCount); }
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

        private async void Update()
        {
            Cars = await _cloudService.ReadAllCar(_cloudService.User.Id);
            ParkPoint = _cloudService.User.ParkPoint;
            SuccessDealCount = _cloudService.User.SuccessDealCount;
            FailDealCount = _cloudService.User.FailDealCount;
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
            SearchUpdate();
        }

        private void SearchUpdate()
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
