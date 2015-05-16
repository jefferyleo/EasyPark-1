using System;
using System.IO;
using Cirrious.MvvmCross.Plugins.PictureChooser;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Models;
using EasyPark.Core.Services;

namespace EasyPark.Core.ViewModels
{
    public class CarViewModel
        : MvxViewModel
    {
        private readonly ICloudService _cloudService;
        private readonly IMvxPictureChooserTask _pictureChooserTask;

        public CarViewModel(ICloudService cloudService, IMvxPictureChooserTask pictureChooserTask)
        {
            _cloudService = cloudService;
            _pictureChooserTask = pictureChooserTask;
            StatusText = "Easy Park";
            IsLoading = false;
            Action = Car != null ? Action.Update : Action.Create;
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

        private Car _car;
        public Car Car
        {
            get { return _car; }
            set { _car = value; RaisePropertyChanged(() => Car); }
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

        private byte[] _pictureBytes;
        public byte[] PictureBytes
        {
            get { return _pictureBytes; }
            set { _pictureBytes = value; RaisePropertyChanged(() => PictureBytes); }
        }

        private void Update()
        {
            if (_car != null)
            {
                _car.Manufacturer = Manufacturer;
                _car.Model = Model;
                _car.CarPlateNumber = CarPlateNumber;
                _car.Color = Color;
                _car.PictureBytes = PictureBytes;
            }
        }

        private void OnPicture(Stream stream)
        {
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            PictureBytes = memoryStream.ToArray();
        }

        MvxCommand _cameraPictureCommand;
        public System.Windows.Input.ICommand CameraPictureCommand
        {
            get
            {
                _cameraPictureCommand = _cameraPictureCommand ?? new MvxCommand(DoCameraPictureCommand);
                return _cameraPictureCommand;
            }
        }

        private void DoCameraPictureCommand()
        {
            _pictureChooserTask.TakePicture(400, 100, OnPicture, () => { /* nothing to do */});
        }

        MvxCommand _galleryPictureCommand;
        public System.Windows.Input.ICommand GalleryPictureCommand
        {
            get
            {
                _galleryPictureCommand = _galleryPictureCommand ?? new MvxCommand(DoGalleryPictureCommand);
                return _galleryPictureCommand;
            }
        }

        private void DoGalleryPictureCommand()
        {
            _pictureChooserTask.ChoosePictureFromLibrary(400, 100, OnPicture, () => { /* nothing to do */});
        }

        MvxCommand _insertUpdateCarCommand;
        public System.Windows.Input.ICommand InsertUpdateCarCommand
        {
            get
            {
                _insertUpdateCarCommand = _insertUpdateCarCommand ?? new MvxCommand(DoInsertUpdateCarCommand);
                return _insertUpdateCarCommand;
            }
        }

        private void DoInsertUpdateCarCommand()
        {
            IsLoading = true;
            if (Action == Action.Create)
            {
                StatusText = "Creating...";
                _car = new Car()
                {
                    Id = Guid.NewGuid().ToString(),
                    Manufacturer = Manufacturer,
                    Model = Model,
                    CarPlateNumber = CarPlateNumber,
                    Color = Color,
                    PictureBytes = PictureBytes,
                    UserId = _cloudService.User.Id
                };

                _cloudService.Insert(_car);
            }
            else
            {
                StatusText = "Updating...";
                _cloudService.Update(_car);
            }
            StatusText = "Easy Park";
            IsLoading = false;
            Close(this);
        }
    }
}
