using System;
using EasyPark.Core.Models;

namespace EasyPark.Core.Services
{
    public interface IPlaceService
    {
        void StartNearBySearchAsync(double lat, double lng, Action<PlaceSearchResult> success, Action<Exception> error);
        void StartSearchAsync(string searchKey, Action<PlaceSearchResult> success, Action<Exception> error);
    }
}
