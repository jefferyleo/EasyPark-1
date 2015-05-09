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
            // pplKey AIzaSyD3jfeMZK1SWfRFDgMfxn_zrGRSjE7S8Vg
            // myKey AIzaSyCe7b0qkqLMnXsdAxd9-6DXIKtxzhFeDL0
            string address = string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=1500&types=shopping_mall|parking&sensor=false&rankby=distance&key=AIzaSyCe7b0qkqLMnXsdAxd9-6DXIKtxzhFeDL0", lat, lng);
            _simpleRestService.MakeRequest(address, "GET", success, error);
        }

        public void StartSearchAsync(string searchKey, double lat, double lng, Action<PlaceSearchResult> success, Action<Exception> error)
        {
            string address = string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?query={0}&location={1},{2}&radius=10000&types=shopping_mall|parking&sensor=false&key=AIzaSyCe7b0qkqLMnXsdAxd9-6DXIKtxzhFeDL0", Uri.EscapeDataString(searchKey), lat, lng);
            _simpleRestService.MakeRequest(address, "GET", success, error);
        }
    }
}
