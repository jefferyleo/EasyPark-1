using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace EasyPark.MobileService.DataObjects
{
    public class Deal : EntityData
    {
        public int ExtendTimeCount { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool ContributorDealed { get; set; }
        public bool RequestorDealed { get; set; }
        public bool Success { get; set; }
        [ForeignKey("Contribute")]
        public string ContributeId { get; set; }
        [ForeignKey("Request")]
        public string RequestId { get; set; }

        // [ForeignKey("ContributeId")]
        public virtual Contribute Contribute { get; set; }
        // [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
