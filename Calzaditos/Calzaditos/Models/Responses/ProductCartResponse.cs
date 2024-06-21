namespace Calzaditos.Models.Responses
{
    public class ProductCartResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string? ProductDescription { get; set; }
        public int Units { get; set; }
        public string? ProductImageUrl { get; set; }
        public decimal Size { get; set; }
    }
}
