using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class Contribute : EntityData
    {
        [Required]
        public string DestinationPlace { get; set; }
        [Required, DefaultValue("Available")]
        public string Status { get; set; }
        [Required]
        public string CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
        public virtual Deal Deal { get; set; }
    }
}
