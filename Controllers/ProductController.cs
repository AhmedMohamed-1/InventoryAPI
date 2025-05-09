using CRUD_API.DTOs.ProductDTOs;
using CRUD_API.Services.ProductServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductDto> _createProductValidator;
        private readonly IValidator<UpdateProductDto> _updateProductValidator;
        public ProductController(IProductService productService , IValidator<CreateProductDto> createProductValidator, IValidator<UpdateProductDto> updateProductValidator)
        {
            _productService = productService;
            _createProductValidator = createProductValidator;
            _updateProductValidator = updateProductValidator; 
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CreateProductDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            ValidationResult validationResult = await _createProductValidator.ValidateAsync(productDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var createdProduct = await _productService.CreateAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UpdateProductDto updateDto)
        {
            ValidationResult validationResult = await _updateProductValidator.ValidateAsync(updateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var updatedProduct = await _productService.UpdateAsync(id, updateDto);
            if (updatedProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(deleted);
        }




    }
}
