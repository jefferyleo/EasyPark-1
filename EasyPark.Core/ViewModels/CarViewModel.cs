using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Models;
using EasyPark.Core.Services;

namespace EasyPark.Core.ViewModels
{
    public class CarViewModel
        : MvxViewModel
    {
        private Car _car;
        private readonly ICloudService _cloudService;

        public CarViewModel(ICloudService cloudService)
        {
            _cloudService = cloudService;
        }

        private Action _action;
        public Action Action
        {
            get { return _action; }
            set { _action = value; RaisePropertyChanged(() => Action); }
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; RaisePropertyChanged(() => Manufacturer); Update(); }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set { _model = value; RaisePropertyChanged(() => Model); Update(); }
        }

        private string _carPlateNumber;
        public string CarPlateNumber
        {
            get { return _carPlateNumber; }
            set { _carPlateNumber = value; RaisePropertyChanged(() => CarPlateNumber); Update(); }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { _color = value; RaisePropertyChanged(() => Color); Update(); }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; RaisePropertyChanged(() => ImageUrl); Update(); }
        }

        private void Update()
        {
            if (_car != null)
            {
                _car.Manufacturer = Manufacturer;
                _car.Model = Model;
                _car.CarPlateNumber = CarPlateNumber;
                _car.Color = Color;
                _car.ImageUrl = ImageUrl;
            }
        }

        MvxCommand _insertUpdateCar;
        public System.Windows.Input.ICommand InsertUpdateCar
        {
            get
            {
                _insertUpdateCar = _insertUpdateCar ?? new MvxCommand(DoInsertUpdateCar);
                return _insertUpdateCar;
            }
        }

        private void DoInsertUpdateCar()
        {
            if (Action == Action.Create)
            {
                _car = new Car()
                {
                    Manufacturer = Manufacturer,
                    Model = Model,
                    CarPlateNumber = CarPlateNumber,
                    Color = Color,
                    ImageUrl = ImageUrl,
                    UserId = _cloudService.CurrentUser.UserId
                };

                _cloudService.Insert(_car);
            }
            else
            {
                _cloudService.Update(_car);
            }
        }
    }
}
