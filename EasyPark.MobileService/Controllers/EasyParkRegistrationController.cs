using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using EasyPark.MobileService.DataObjects;
using EasyPark.MobileService.Models;
using EasyPark.MobileService.Requests;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace EasyPark.MobileService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class EasyParkRegistrationController : ApiController
    {
        public ApiServices Services { get; set; }

        // POST api/CustomRegistration
        public HttpResponseMessage Post(RegistrationRequest registrationRequest)
        {
            if (!Regex.IsMatch(registrationRequest.UserName, @"^[a-zA-Z0-9\._]{4,}$"))
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid username (at least 4 chars, alphanumeric only)!");
            }
            else if (registrationRequest.Password.Length < 6)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid password (at least 6 chars required)!");
            }

            EasyParkContext context = new EasyParkContext();
            User user = context.Users.SingleOrDefault(u => u.UserName == registrationRequest.UserName);
            if (user != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Username already exists!");
            }
            else
            {
                User newUser = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = registrationRequest.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(registrationRequest.Password, BCrypt.Net.BCrypt.GenerateSalt()),
                    FirstName = registrationRequest.FirstName,
                    LastName = registrationRequest.LastName,
                    DateOfBirth = registrationRequest.DateOfBirth,
                    EMail = registrationRequest.EMail,
                    Contact = registrationRequest.Contact
                };
                context.Users.Add(newUser);
                context.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.Created);
            }
        }
    }
}
