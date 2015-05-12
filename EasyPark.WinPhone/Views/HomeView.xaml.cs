using System;
using System.Device.Location;
using System.Windows;
using System.Windows.Controls;
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
            ApplicationBar = ((ApplicationBar)this.Resources["CarAppBar"]);
        }

        private void UpdateLocation(object sender, TextChangedEventArgs e)
        {
            GeoCoordinate currentLocation = new GeoCoordinate(Double.Parse(Lat.Text), Double.Parse(Lng.Text));
            Ellipse currentLocationOuterBorder = new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.Black),
                Height = 27,
                Width = 27,
                Opacity = 50
            };
            Ellipse currentLocationBorder = new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.White),
                Height = 24,
                Width = 24,
                Opacity = 50
            };
            Ellipse currentLocationIndicator = new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.Green),
                Height = 19,
                Width = 19,
                Opacity = 50
            };
            MapOverlay currentLocationOuterBorderOverlay = new MapOverlay()
            {
                Content = currentLocationOuterBorder,
                PositionOrigin = new Point(0.5, 0.5),
                GeoCoordinate = currentLocation,
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

            currentLocationLayer.Add(currentLocationOuterBorderOverlay);
            currentLocationLayer.Add(currentLocationBorderOverlay);
            currentLocationLayer.Add(currentLocationOverlay);
            MyMap.Layers.Add(currentLocationLayer);
        }
    }
}