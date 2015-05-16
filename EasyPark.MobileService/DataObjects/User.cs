using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class User : EntityData
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Contact { get; set; }
        [DefaultValue(100)]
        public int ParkPoint { get; set; }
        public int SuccessDealCount { get; set; }
        public int FailDealCount { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
