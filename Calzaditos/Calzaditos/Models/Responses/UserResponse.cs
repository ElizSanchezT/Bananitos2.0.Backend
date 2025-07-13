namespace Calzaditos.Models.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string FullName { get; set; } = default!;
    }
}
