using Cirrious.CrossCore.WindowsPhone.Converters;
using Cirrious.MvvmCross.Plugins.Visibility;
using EasyPark.Core.ValueConverters;

namespace EasyPark.WinPhone.ValueConverters
{
    public class NativeVisibilityValueConverter : MvxNativeValueConverter<MvxVisibilityValueConverter>
    {
    }
    public class NativeInvertedVisibilityValueConverter : MvxNativeValueConverter<MvxInvertedVisibilityValueConverter>
    {
    }
    public class NativeInverseBoolValueConverter : MvxNativeValueConverter<InverseBoolValueConverter>
    {
    }
}
