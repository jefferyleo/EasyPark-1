using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Shell;

namespace EasyPark.WinPhone.Views
{
    public partial class LoginView : MvxPhonePage
    {
        public LoginView()
        {
            InitializeComponent();

            var prog = new ProgressIndicator { Text = "Easy Park", IsVisible = true, IsIndeterminate = false, Value = 0 };
            SystemTray.SetProgressIndicator(this, prog);
        }
    }
}