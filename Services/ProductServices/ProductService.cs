using CRUD_API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CRUD_API.DTOs.ProductDTOs;
using CRUD_API.Repositories.ProductRepositories;

namespace CRUD_API.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly InventoryContext _context;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger, IMapper mapper, InventoryContext context)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return product != null ? _mapper.Map<ProductDto>(product) : null;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var created = await _productRepository.AddProductAsync(product);
            return _mapper.Map<ProductDto>(created);
        }

        public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
        {
            var existing = await _productRepository.GetProductByIdAsync(id);
            if (existing == null)
            {
                _logger.LogWarning("Product with ID {Id} not found for update.", id);
                return null;
            }

            // Validate SupplierId if provided
            if (dto.SupplierId.HasValue)
            {
                var supplierExists = await _context.Suppliers.AnyAsync(s => s.Id == dto.SupplierId.Value);
                if (!supplierExists)
                {
                    _logger.LogWarning("Supplier with ID {SupplierId} not found.", dto.SupplierId.Value);
                    return null;
                }
            }

            _mapper.Map(dto, existing); // Updates existing product with allowed fields
            var updated = await _productRepository.UpdateProductAsync(existing);
            return _mapper.Map<ProductDto>(updated); // Return the full product DTO including Id
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _productRepository.GetProductByIdAsync(id);
            if (existing == null)
            {
                _logger.LogWarning("Product with ID {Id} not found for deletion.", id);
                return false;
            }

            await _productRepository.DeleteProductAsync(existing);
            return true;
        }
    }
}
