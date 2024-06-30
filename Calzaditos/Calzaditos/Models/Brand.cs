namespace Calzaditos.Models
{
    public class Brand : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public List<Product> Products { get; set; } = [];
    }
}
