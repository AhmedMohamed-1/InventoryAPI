using CRUD_API.DTOs.SupplierDTOs;

namespace CRUD_API.Services.SupplierServices
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto?> GetSupplierByIdAsync(int id);
        Task<SupplierDto> AddSupplierAsync(CreateSupplierDto supplier);
        Task<SupplierDto?> UpdateSupplierAsync(int id, UpdateSupplierDto supplier);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
