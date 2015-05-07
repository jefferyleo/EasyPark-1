using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EasyPark.Core.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace EasyPark.Core.Services
{
    public interface ICloudService
    {
        MobileServiceUser CurrentUser { get; }

        // Web API
        Task Login(string userName, string password);
        Task SignUp(string userName, string password, string firstName, string lastName, DateTime dateOfBirth, string eMail, string contactNumber);

        // User
        Task Update(User user);

        // Car
        Task Insert(Car car);
        Task<Car> Read(string id);
        //Task<ObservableCollection<TodoItem>> ReadAll();
        Task Update(Car car);
        Task Delete(Car car);

        // TodoItem
        Task<ObservableCollection<TodoItem>> GetAll();
        Task SaveAll(ObservableCollection<TodoItem> entities);
    }
}