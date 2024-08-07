﻿namespace Calzaditos.Models.Responses
{
    public class ProductCartResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
        public string? ImageUrl { get; set; }
        public int Size { get; set; }
    }
}
