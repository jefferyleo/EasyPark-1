using System;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using EasyPark.Core.Services;

namespace EasyPark.Core.ViewModels
{
    public class SignUpViewModel
        : MvxViewModel
    {
        private readonly ICloudService _service;

        public SignUpViewModel(ICloudService service)
        {
            _service = service;
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

        private string _day;
        public string Day
        {
            get { return _day; }
            set { _day = value; RaisePropertyChanged(() => Day); }
        }

        private string _month;
        public string Month
        {
            get { return _month; }
            set { _month = value; RaisePropertyChanged(() => Month); }
        }

        private string _year;
        public string Year
        {
            get { return _year; }
            set { _year = value; RaisePropertyChanged(() => Year); }
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

        private string _contact;
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; RaisePropertyChanged(() => Contact); }
        }

        private bool _agreeTerm;
        public bool AgreeTerm
        {
            get { return _agreeTerm; }
            set { _agreeTerm = value; RaisePropertyChanged(() => AgreeTerm); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; RaisePropertyChanged(() => ErrorMessage); }
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

        private async void DoSignUpCommand()
        {
            // To do SignUpCommand()
            ErrorMessage = "";
            DateTime dateOfBirth = new DateTime();
            if (!AgreeTerm)
                ErrorMessage += "*Please agree to the terms and condition." + Environment.NewLine;
            if (FirstName == null)
                ErrorMessage += "*First Name field is required." + Environment.NewLine;
            if (LastName == null)
                ErrorMessage += "*Last Name field is required." + Environment.NewLine;
            if (Day == null || Month == null || Year == null)
                ErrorMessage += "*Date Of Birth field is required." + Environment.NewLine;
            else if (!DateTime.TryParse(Year + "-" + Month + "-" + Day, out dateOfBirth))
                ErrorMessage += "*Date of Birth value is invalid." + Environment.NewLine;
            if(UserName == null )
                ErrorMessage += "*Username field is required." + Environment.NewLine;
            else if (UserName.Length < 6)
                ErrorMessage += "*Username length should be more than 6." + Environment.NewLine;
            if (Password == null)
                ErrorMessage += "*Password field is required." + Environment.NewLine;
            else if (Password != ConfirmPassword)
                ErrorMessage += "*Password are unmatched." + Environment.NewLine;
            if (EMail == null)
                ErrorMessage += "*EMail field is required." + Environment.NewLine;
            if (Contact == null)
                ErrorMessage += "*Contact Number field is required." + Environment.NewLine;

            if (ErrorMessage != "") return;
            try
            {
                await _service.SignUp(UserName, Password, FirstName, LastName, dateOfBirth, EMail, Contact);
                ErrorMessage = "Register successfully!";
                await Task.Delay(500);
                Close(this);
            }
            catch (Exception ex)
            {
                ErrorMessage = "*" + ex.Message;
            }
        }
    }
}
