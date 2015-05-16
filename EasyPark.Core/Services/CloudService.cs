using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EasyPark.Core.Models;
using EasyPark.Core.Requests;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace EasyPark.Core.Services
{
    public class CloudService : ICloudService
    {
        private readonly MobileServiceClient _mobileService = new MobileServiceClient(
            @"https://easypark.azure-mobile.net/",
            @"wFEkMHIyfvKbdySqvgmMVNxHrLuyzC88");
        private IMobileServiceTable<User> _users;
        private IMobileServiceTable<Car> _cars;

        public CloudService()
        {
            _users = _mobileService.GetTable<User>();
            _cars = _mobileService.GetTable<Car>();
        }

        public User User { get; set; }

        public MobileServiceUser CurrentUser
        {
            get { return _mobileService.CurrentUser; }
        }

        public async Task Login(string userName, string password)
        {
            LoginRequest loginRequest = new LoginRequest() { UserName = userName, Password = password };
            var loginResponse = await _mobileService.InvokeApiAsync("EasyParkLogin", JToken.FromObject(loginRequest));
            JObject loginResult = JObject.Parse(loginResponse.ToString());
            _mobileService.CurrentUser = new MobileServiceUser(loginResult["user"]["userId"].ToString().Replace("EasyPark:", ""))
            {
                MobileServiceAuthenticationToken = loginResult["authenticationToken"].ToString()
            };
            User = await ReadUser(loginResult["user"]["userId"].ToString().Replace("EasyPark:", ""));
        }

        public async Task SignUp(string userName, string password, string firstName, string lastName, DateTime dateOfBirth, string eMail, string contactNumber)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { UserName = userName, Password = password, FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth, EMail = eMail, Contact = contactNumber };
            await _mobileService.InvokeApiAsync("EasyParkRegistration", JToken.FromObject(registrationRequest));
        }

        public async Task Update(User user)
        {
            await _users.UpdateAsync(user);
        }

        public async Task<User> ReadUser(string id)
        {
            return await _users.LookupAsync(id);
        }

        public async Task Insert(Car car)
        {
            await _cars.InsertAsync(car);
        }

        public async Task<Car> ReadCar(string id)
        {
            return await _cars.LookupAsync(id);
        }

        public async Task<List<Car>> ReadAllCar(string userId)
        {
            return await _cars
                //.Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task Update(Car car)
        {
            await _cars.UpdateAsync(car);
        }

        public async Task Delete(Car car)
        {
            await _cars.DeleteAsync(car);
        }

        private void ReportError(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
