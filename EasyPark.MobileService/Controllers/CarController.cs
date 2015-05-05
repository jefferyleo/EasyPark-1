using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using EasyPark.MobileService.DataObjects;
using EasyPark.MobileService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace EasyPark.MobileService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class CarController : TableController<Car>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            EasyParkContext context = new EasyParkContext();
            DomainManager = new EntityDomainManager<Car>(context, Request, Services);
        }

        // GET tables/Car
        public IQueryable<Car> GetAllCar()
        {
            return Query(); 
        }

        // GET tables/Car/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Car> GetCar(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Car/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Car> PatchCar(string id, Delta<Car> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Car
        public async Task<IHttpActionResult> PostCar(Car item)
        {
            Car current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Car/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCar(string id)
        {
             return DeleteAsync(id);
        }

    }
}