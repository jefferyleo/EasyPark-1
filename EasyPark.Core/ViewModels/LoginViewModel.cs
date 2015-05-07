using System;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Services;
using Microsoft.WindowsAzure.MobileServices;

namespace EasyPark.Core.ViewModels
{
    public class LoginViewModel 
		: MvxViewModel
    {
        private readonly ICloudService _service;

        public LoginViewModel(ICloudService service)
        {
            _service = service;
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(() => UserName); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; RaisePropertyChanged(() => ErrorMessage); }
        }

        MvxCommand _loginCommand;
        public System.Windows.Input.ICommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new MvxCommand(DoLoginCommand);
                return _loginCommand;
            }
        }

        private async void DoLoginCommand()
        {
            ErrorMessage = "";
            try
            {
                await _service.Login(UserName, Password);
                ShowViewModel<HomeViewModel>();
                Close(this);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        MvxCommand _signUpCommand;
        public System.Windows.Input.ICommand SignUpCommand
        {
            get
            {
                _signUpCommand = _signUpCommand ?? new MvxCommand(DoSignUpCommand);
                return _signUpCommand;
            }
        }

        private void DoSignUpCommand()
        {
            ShowViewModel<SignUpViewModel>();
        }
    }
}
