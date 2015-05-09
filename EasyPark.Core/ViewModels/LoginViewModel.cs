using System;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Services;
using Microsoft.WindowsAzure.MobileServices;

namespace EasyPark.Core.ViewModels
{
    public class LoginViewModel 
		: MvxViewModel
    {
        private readonly ICloudService _cloudService;

        public LoginViewModel(ICloudService cloudService)
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
                StatusText = "Logging in...";
                IsLoading = true;
                await _cloudService.Login(UserName, Password);
                StatusText = "Easy Park";
                IsLoading = false;
                ShowViewModel<HomeViewModel>();
                //Close(this);
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
