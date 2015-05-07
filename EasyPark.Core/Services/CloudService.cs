using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using EasyPark.Core.Models;
using EasyPark.Core.Requests;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

namespace EasyPark.Core.Services
{
    public class CloudService : ICloudService
    {
        private readonly MobileServiceClient _service = new MobileServiceClient(
            @"https://easypark.azure-mobile.net/",
            @"RizdSWhhmucIswckIGIBcKmGelsWqe70");

        private IMobileServiceTable<TodoItem> _todoItems;
        private IMobileServiceTable<User> _users;
        private IMobileServiceTable<Car> _cars;

        public CloudService()
        {
            _todoItems = _service.GetTable<TodoItem>();
            _users = _service.GetTable<User>();
            _cars = _service.GetTable<Car>();
            _currentUser = _service.CurrentUser;
        }

        private readonly MobileServiceUser _currentUser;
        public MobileServiceUser CurrentUser
        {
            get { return this._currentUser; }
        }

        public async Task Login(string userName, string password)
        {
            LoginRequest loginRequest = new LoginRequest() { UserName = userName, Password = password };
            try
            {
                var loginResponse = await _service.InvokeApiAsync("EasyParkLogin", JToken.FromObject(loginRequest));
                JObject loginResult = JObject.Parse(loginResponse.ToString());
                _service.CurrentUser = new MobileServiceUser(loginResult["user"]["userId"].ToString().Replace("EasyPark:", ""))
                {
                    MobileServiceAuthenticationToken = loginResult["authenticationToken"].ToString()
                };
                // return true;
            }
            catch (Exception ex)
            {
                // return false;
                throw ex;
            }
        }

        public async Task SignUp(string userName, string password, string firstName, string lastName, DateTime dateOfBirth, string eMail, string contactNumber)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { UserName = userName, Password = password, FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth, EMail = eMail, Contact = contactNumber };
            try
            {
                var registrationResponse = await _service.InvokeApiAsync("EasyParkRegistration", JToken.FromObject(registrationRequest));
                // JObject registrationResult = JObject.Parse(registrationResponse.ToString());
                // To do deserialize json
                // return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                await _users.UpdateAsync(user);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        public async Task Insert(Car car)
        {
            try
            {
                await _cars.InsertAsync(car);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        public async Task<Car> Read(string id)
        {
            Car car = null;

            try
            {
                car = await _cars.LookupAsync(id);
            }
            catch (Exception e)
            {
                ReportError(e);
            }

            return car;
        }

        public async Task Update(Car car)
        {
            try
            {
                await _cars.UpdateAsync(car);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        public async Task Delete(Car car)
        {
            try
            {
                await _cars.DeleteAsync(car);
            }
            catch (Exception e)
            {
                ReportError(e);
            }
        }

        public async Task<ObservableCollection<TodoItem>> GetAll()
        {
            ObservableCollection<TodoItem> todoItems = new ObservableCollection<TodoItem>();

            try
            {
                todoItems = await _todoItems.ToCollectionAsync<TodoItem>();
            }
            catch (Exception ex)
            {

                ReportError(ex);
            }

            return todoItems;
        }

        public async Task SaveAll(ObservableCollection<TodoItem> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                try
                {
                    var theTable = _service.GetTable<TodoItem>();

                    foreach (TodoItem todoItem in entities)
                        await theTable.InsertAsync(todoItem);
                }
                catch (Exception ex)
                {
                    ReportError(ex);
                }
            }
        }

        private void ReportError(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
