﻿namespace Calzaditos.Models.Requests
{
    public class CreateUserRequest
    {
        public string UserName { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
