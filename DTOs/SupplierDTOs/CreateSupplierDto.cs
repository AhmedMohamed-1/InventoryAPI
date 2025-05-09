namespace CRUD_API.DTOs.SupplierDTOs
{
    public class CreateSupplierDto
    {
        public string Name { get; set; } = null!;

        public string? ContactEmail { get; set; }

        public string? Phone { get; set; }
    }
}
