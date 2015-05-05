using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using EasyPark.MobileService.DataObjects;
using EasyPark.MobileService.Models;

namespace EasyPark.MobileService.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EasyParkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EasyParkContext context)
        {
            //List<TodoItem> todoItems = new List<TodoItem>
            //{
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
            //    new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            //};
            //todoItems.ForEach(u => context.TodoItems.AddOrUpdate(i => i.Text, u));
            //context.SaveChanges();

            //List<User> users = new List<User>
            //{
            //    new User { Id = Guid.NewGuid().ToString(), FirstName = "Chris", LastName = "Lui", DateOfBirth = DateTime.Parse("1993/10/15"), UserName = "chrislyr93", Password = BCrypt.Net.BCrypt.HashPassword("chrislui", BCrypt.Net.BCrypt.GenerateSalt()), EMail = "chris_lui93@hotmail.com", Contact = "0126211640" },
            //    new User { Id = Guid.NewGuid().ToString(), FirstName = "Bosco", LastName = "Lam", DateOfBirth = DateTime.Parse("1993/3/10"), UserName = "boscolam", Password = BCrypt.Net.BCrypt.HashPassword("boscolam", BCrypt.Net.BCrypt.GenerateSalt()), EMail = "boscolam93@hotmail.com", Contact = "0122232833" }
            //};
            //users.ForEach(u => context.Users.AddOrUpdate(i => i.FirstName, u));
            //context.SaveChanges();

            //List<Car> cars = new List<Car>
            //{
            //    new Car { Id = Guid.NewGuid().ToString(), Manufacturer = "McLaren", Model = "MP4-12c", CarPlateNumber = "MP 412 C", Color = "White", ImageUrl = "image", UserId = users.Single(u => u.UserName == "chrislyr93").Id },
            //    new Car { Id = Guid.NewGuid().ToString(), Manufacturer = "Lamborghini", Model = "Aventador", CarPlateNumber = "AVE 14", Color = "Dark Space Grey", ImageUrl = "image", UserId = users.Single(u => u.UserName == "boscolam").Id }
            //};
            //cars.ForEach(c => context.Cars.AddOrUpdate(i => i.Manufacturer, c));
            //context.SaveChanges();
        }
    }
}
