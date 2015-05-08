using System;
using EasyPark.Core.Models;

namespace EasyPark.Core.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly ISimpleRestService _simpleRestService;

        public PlaceService(ISimpleRestService simpleRestService)
        {
            _simpleRestService = simpleRestService;
        }

        public void StartNearBySearchAsync(double lat, double lng, Action<PlaceSearchResult> success, Action<Exception> error)
        {
            string address = string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=1500&types=shopping_mall|parking&sensor=false&key=AIzaSyD3jfeMZK1SWfRFDgMfxn_zrGRSjE7S8Vg", lat, lng);
            _simpleRestService.MakeRequest(address, "GET", success, error);
        }

        public void StartSearchAsync(string searchKey, Action<PlaceSearchResult> success, Action<Exception> error)
        {
            string address = string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?query={0}&types=shopping_mall|parking&sensor=false&key=AIzaSyD3jfeMZK1SWfRFDgMfxn_zrGRSjE7S8Vg", Uri.EscapeDataString(searchKey));
            _simpleRestService.MakeRequest(address, "GET", success, error);
        }
    }
}
