using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EasyPark.Core.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace EasyPark.Core.Services
{
    public interface ICloudService
    {
        User User { get; }
        MobileServiceUser CurrentUser { get; }

        // Web API
        Task Login(string userName, string password);
        Task SignUp(string userName, string password, string firstName, string lastName, DateTime dateOfBirth, string eMail, string contactNumber);

        // User
        Task Update(User user);
        Task<User> ReadUser(string id);

        // Car
        Task Insert(Car car);
        Task<Car> ReadCar(string id);
        Task<List<Car>> ReadAllCar(string userId);
        Task Update(Car car);
        Task Delete(Car car);
    }
}