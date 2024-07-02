namespace Calzaditos.Models.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Discount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int BrandId { get; set; }
        public List<int> Sizes { get; set; } = [];

    }
}
