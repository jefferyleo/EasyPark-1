using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EasyPark.Core.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string EMail { get; set; }

        [JsonProperty(PropertyName = "contact")]
        public string Contact { get; set; }

        [JsonProperty(PropertyName = "parkpoint")]
        public int ParkPoint { get; set; }

        [JsonProperty(PropertyName = "successdealcount")]
        public int SuccessDealCount { get; set; }

        [JsonProperty(PropertyName = "faildealcount")]
        public int FailDealCount { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "cars")]
        public virtual ICollection<Car> Cars { get; set; }
    }
}