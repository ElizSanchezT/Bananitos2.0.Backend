namespace Calzaditos.Models
{
    public class Cart : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
