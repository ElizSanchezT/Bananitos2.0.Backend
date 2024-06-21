namespace Calzaditos.Models
{
    public class Brand : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public List<Product> Products { get; set; } = [];
    }
}
