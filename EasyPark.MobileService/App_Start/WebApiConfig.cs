using System.Data.Entity.Migrations;
using System.Web.Http;
using EasyPark.MobileService.Migrations;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace EasyPark.MobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.SetIsHosted(true);
            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //Database.SetInitializer(new EasyParkInitializer());
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }

    //public class EasyParkInitializer : DropCreateDatabaseIfModelChanges<EasyParkContext> // ClearDatabaseSchemaIfModelChanges<EasyParkContext>
    //{
    //    protected override void Seed(EasyParkContext context)
    //    {
    //        List<TodoItem> todoItems = new List<TodoItem>
    //        {
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
    //        };
    //        todoItems.ForEach(s => context.TodoItems.Add(s));
    //        context.SaveChanges();

    //        List<User> users = new List<User>
    //        {
    //            new User { Id = Guid.NewGuid().ToString(), FirstName = "Chris", LastName = "Lui", DateOfBirth = DateTime.Parse("15/10/1993"), UserName = "chrislyr93", Password = "admin", EMail = "chris_lui93@hotmail.com", Contact = "0126211640"  }, // , Cars = new Collection<Car> { cars[0]}
    //            new User { Id = Guid.NewGuid().ToString(), FirstName = "Bosco", LastName = "Lam", DateOfBirth = DateTime.Parse("10/3/1993"), UserName = "boscolam", Password = "user", EMail = "boscolam93@hotmail.com", Contact = "0122232833"  } // , Cars = new Collection<Car> { cars[1]}
    //        };
    //        users.ForEach(s => context.Users.Add(s));
    //        context.SaveChanges();

    //        List<Car> cars = new List<Car>
    //        {
    //            new Car { Id = Guid.NewGuid().ToString(), Manufacturer = "McLaren", Model = "MP4-12c" , CarPlateNumber = "MP 412 C" , Color = "White", ImageUrl="image", User = users[0] },
    //            new Car { Id = Guid.NewGuid().ToString(), Manufacturer = "Lamborghini", Model = "Aventador" , CarPlateNumber = "AVE 14" , Color = "Dark Space Grey", ImageUrl="image", User = users[1] }
    //        };
    //        cars.ForEach(s => context.Cars.Add(s));
    //        context.SaveChanges();

    //        base.Seed(context);
    //    }
    //}
}

