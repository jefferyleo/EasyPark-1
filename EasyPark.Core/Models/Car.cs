using Newtonsoft.Json;

namespace EasyPark.Core.Models
{
    public class Car
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "carplatenumber")]
        public string CarPlateNumber { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "imageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "user")]
        public virtual User User { get; set; }
    }
}