using System;
using System.Device.Location;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;

namespace EasyPark.WinPhone.Views
{
    public partial class HomeView : MvxPhonePage
    {
        public HomeView()
        {
            InitializeComponent();

            var prog = new ProgressIndicator { Text = "Easy Park", IsVisible=true, IsIndeterminate=false, Value=0 };
            SystemTray.SetProgressIndicator(this, prog);
        }

        private void UpdateLocation(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            GeoCoordinate currentLocation = new GeoCoordinate(Double.Parse(Lat.Text), Double.Parse(Lng.Text));
            Ellipse currentLocationBorder = new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.DarkGray),
                Height = 25,
                Width = 25,
                Opacity = 50
            };
            Ellipse currentLocationIndicator = new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.Green),
                Height = 18,
                Width = 18,
                Opacity = 50
            };
            MapOverlay currentLocationBorderOverlay = new MapOverlay()
            {
                Content = currentLocationBorder,
                PositionOrigin = new Point(0.5, 0.5),
                GeoCoordinate = currentLocation,
            };
            MapOverlay currentLocationOverlay = new MapOverlay()
            {
                Content = currentLocationIndicator,
                PositionOrigin = new Point(0.5, 0.5),
                GeoCoordinate = currentLocation,
            };
            MapLayer currentLocationLayer = new MapLayer();
            
            MyMap.Center = currentLocation;
            MyMap.Layers.Clear();

            currentLocationLayer.Add(currentLocationBorderOverlay);
            currentLocationLayer.Add(currentLocationOverlay);
            MyMap.Layers.Add(currentLocationLayer);
        }
    }
}