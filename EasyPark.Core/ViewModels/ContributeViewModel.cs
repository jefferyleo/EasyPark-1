using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Models;
using EasyPark.Core.Services;

namespace EasyPark.Core.ViewModels
{
    public class ContributeViewModel
        : MvxViewModel
    {
        private readonly ICloudService _cloudService;

        public ContributeViewModel(ICloudService cloudService)
        {
            _cloudService = cloudService;
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

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; RaisePropertyChanged(() => ImageUrl); }
        }

        private List<Car> _cars;
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; RaisePropertyChanged(() => Cars); }
        }

        private string _selectedCar;
        public string SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; RaisePropertyChanged(() => SelectedCar); }
        }

        private string _carParkLot;
        public string CarParkLot
        {
            get { return _carParkLot; }
            set { _carParkLot = value; RaisePropertyChanged(() => CarParkLot); }
        }

        private string _carParkFloor;
        public string CarParkFloor
        {
            get { return _carParkFloor; }
            set { _carParkFloor = value; RaisePropertyChanged(() => CarParkFloor); }
        }

        private string _carParkSlot;
        public string CarParkSlot
        {
            get { return _carParkSlot; }
            set { _carParkSlot = value; RaisePropertyChanged(() => CarParkSlot); }
        }
    }
}
