namespace CRUD_API.DTOs.SupplierDTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ContactEmail { get; set; }

        public string? Phone { get; set; }
    }
}
