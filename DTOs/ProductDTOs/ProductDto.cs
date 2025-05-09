namespace CRUD_API.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? SupplierName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
