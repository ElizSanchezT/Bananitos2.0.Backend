namespace Calzaditos.Models
{
    public class ProductCart
    {
        public int Id { get; set; }
        public int Units { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int SelectedSize { get; set; }
        public Product Product { get; set; } = default!;
        public Cart Cart { get; set; } = default!;
    }
}
