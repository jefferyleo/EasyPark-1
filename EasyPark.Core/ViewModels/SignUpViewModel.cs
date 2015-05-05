using System;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Services;

namespace EasyPark.Core.ViewModels
{
    public class SignUpViewModel
        : MvxViewModel
    {
        private readonly ICloudService _cloudService;

        public SignUpViewModel(ICloudService cloudService)
        {
            _cloudService = cloudService;
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(() => FirstName); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(() => LastName); }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; RaisePropertyChanged(() => DateOfBirth); }
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; RaisePropertyChanged(() => ConfirmPassword); }
        }

        private string _eMail;
        public string EMail
        {
            get { return _eMail; }
            set { _eMail = value; RaisePropertyChanged(() => EMail); }
        }

        private string _contactNumber;
        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; RaisePropertyChanged(() => ContactNumber); }
        }

        private bool _agreeTerm;
        public bool AgreeTerm
        {
            get { return _agreeTerm; }
            set { _agreeTerm = value; RaisePropertyChanged(() => AgreeTerm); }
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
            // To do SignUpCommand()
            
        }
    }
}
