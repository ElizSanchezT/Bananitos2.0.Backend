namespace Calzaditos.Models.Requests
{
    public class AddProductToCartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; } = default!;
    }
}
