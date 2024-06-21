namespace Calzaditos.Models.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<ProductCartResponse> Products { get; set; } = [];
    }
}
