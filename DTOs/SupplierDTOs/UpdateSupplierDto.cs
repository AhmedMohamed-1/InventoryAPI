namespace CRUD_API.DTOs.SupplierDTOs
{
    public class UpdateSupplierDto
    {
        public string Name { get; set; } = null!;

        public string? ContactEmail { get; set; }

        public string? Phone { get; set; }
    }
}
