using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class Car : EntityData
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string CarPlateNumber { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
