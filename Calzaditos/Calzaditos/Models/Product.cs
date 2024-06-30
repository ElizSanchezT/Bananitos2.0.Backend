namespace Calzaditos.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        public decimal? Discount { get; set; }
        public Brand Brand { get; set; } = default!;
        public List<ProductSize> Sizes { get; set; } = [];
    }
}
