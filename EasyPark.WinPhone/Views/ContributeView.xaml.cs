using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Shell;

namespace EasyPark.WinPhone.Views
{
    public partial class ContributeView : MvxPhonePage
    {
        public ContributeView()
        {
            InitializeComponent();

            var prog = new ProgressIndicator { Text = "Easy Park", IsVisible = true, IsIndeterminate = false, Value = 0 };
            SystemTray.SetProgressIndicator(this, prog);
        }
    }
}