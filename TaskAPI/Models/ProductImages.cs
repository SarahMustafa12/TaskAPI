using System.Text.Json.Serialization;

namespace TaskAPI.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
