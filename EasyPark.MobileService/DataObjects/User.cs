using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class User : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
