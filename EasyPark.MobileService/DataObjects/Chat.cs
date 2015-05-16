using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class Chat : EntityData
    {
        [Required]
        public string SenderId { get; set; }
        [Required]
        public string ReceiverId { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string DealId { get; set; }
        
        [ForeignKey("DealId")]
        public virtual Deal Deal { get; set; }
    }
}
