using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class Car : EntityData
    {
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string CarPlateNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public byte[] PictureBytes { get; set; }
        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<Contribute> Contributes { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
