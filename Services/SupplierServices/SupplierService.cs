using AutoMapper;
using CRUD_API.DTOs.SupplierDTOs;
using CRUD_API.Models;
using CRUD_API.Repositories.SupplierRepositories;

namespace CRUD_API.Services.SupplierServices
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<SupplierService> _logger;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, ILogger<SupplierService> logger, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto?> GetSupplierByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            return supplier != null ? _mapper.Map<SupplierDto>(supplier) : null;
        }

        public async Task<SupplierDto> AddSupplierAsync(CreateSupplierDto supplier)
        {
            var sup = _mapper.Map<Supplier>(supplier);
            var supplierDto = await _supplierRepository.AddSupplierAsync(sup);
            return _mapper.Map<SupplierDto>(supplierDto);
        }

        public async Task<SupplierDto?> UpdateSupplierAsync(int id, UpdateSupplierDto supplier)
        {
            var sup = await _supplierRepository.GetSupplierByIdAsync(id);
            if (sup == null)
            {
                _logger.LogWarning($"Supplier with id {id} not found.");
                return null;
            }
            _mapper.Map(supplier, sup);
            var supplierDto = await _supplierRepository.UpdateSupplierAsync(sup);
            return _mapper.Map<SupplierDto>(supplierDto);
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                _logger.LogWarning($"Supplier with id {id} not found.");
                return false;
            }
            await _supplierRepository.DeleteSupplierAsync(supplier);
            return true;
        }
    }
}
