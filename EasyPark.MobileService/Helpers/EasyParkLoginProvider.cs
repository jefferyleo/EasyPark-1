using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using Newtonsoft.Json.Linq;
using Owin;

namespace EasyPark.MobileService.Helpers
{
    public class EasyParkLoginProvider : LoginProvider
    {
        public const string ProviderName = "EasyPark";

        public override string Name
        {
            get { return ProviderName; }
        }

        public EasyParkLoginProvider(IServiceTokenHandler tokenHandler)
            : base(tokenHandler)
        {
            this.TokenLifetime = new TimeSpan(30, 0, 0, 0);
        }

        public override void ConfigureMiddleware(IAppBuilder appBuilder, ServiceSettingsDictionary settings)
        {
            // Not Applicable - used for federated identity flows
            return;
        }

        public override ProviderCredentials CreateCredentials(ClaimsIdentity claimsIdentity)
        {
            if (claimsIdentity == null)
            {
                throw new ArgumentNullException("claimsIdentity");
            }

            string id = claimsIdentity.FindFirst(ClaimTypes.PrimarySid).Value;
            EasyParkLoginProviderCredentials credentials = new EasyParkLoginProviderCredentials
            {
                UserId = this.TokenHandler.CreateUserId(this.Name, id)
            };

            return credentials;
        }

        public override ProviderCredentials ParseCredentials(JObject serialized)
        {
            if (serialized == null)
            {
                throw new ArgumentNullException("serialized");
            }

            return serialized.ToObject<EasyParkLoginProviderCredentials>();
        }
    }

    public class EasyParkLoginProviderCredentials : ProviderCredentials
    {
        public EasyParkLoginProviderCredentials()
            : base(EasyParkLoginProvider.ProviderName)
        {

        }
    }
}
