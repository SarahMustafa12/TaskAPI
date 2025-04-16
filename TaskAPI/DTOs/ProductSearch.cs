namespace TaskAPI.DTOs
{
    public class ProductSearch
    {
        public string? CategoryName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Model { get; set; }

    }
}
