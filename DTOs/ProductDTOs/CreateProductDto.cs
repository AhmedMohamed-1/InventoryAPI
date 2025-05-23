﻿namespace CRUD_API.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}
