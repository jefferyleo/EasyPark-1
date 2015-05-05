using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Web.Http;
using EasyPark.MobileService.DataObjects;
using EasyPark.MobileService.Helpers;
using EasyPark.MobileService.Models;
using EasyPark.MobileService.Requests;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace EasyPark.MobileService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class EasyParkLoginController : ApiController
    {
        public ApiServices Services { get; set; }
        public IServiceTokenHandler handler { get; set; }

        // POST api/CustomLogin
        public HttpResponseMessage Post(LoginRequest loginRequest)
        {
            EasyParkContext context = new EasyParkContext();
            User user = context.Users.SingleOrDefault(a => a.UserName == loginRequest.UserName);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity();
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.PrimarySid, user.Id));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginRequest.UserName));
                    LoginResult loginResult = new EasyParkLoginProvider(handler).CreateLoginResult(claimsIdentity, Services.Settings.MasterKey);
                    return this.Request.CreateResponse(HttpStatusCode.OK, loginResult);
                }
            }
            return this.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
        }
    }
}
