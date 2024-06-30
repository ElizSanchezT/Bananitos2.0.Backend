namespace Calzaditos.Models
{
    public class PromoCode : BaseModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Stock { get; set; }
        public string Code { get; set; } = default!;

    }
}
