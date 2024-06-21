namespace Calzaditos.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string PasswordSalt { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public Cart Cart { get; set; } = default!;
    }
}
