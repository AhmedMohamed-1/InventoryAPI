using CRUD_API.DTOs.SupplierDTOs;
using CRUD_API.Services.SupplierServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IValidator<CreateSupplierDto> _createSupplierValidator;
        private readonly IValidator<UpdateSupplierDto> _updateSupplierValidator;

        public SupplierController(
            ISupplierService supplierService,
            IValidator<CreateSupplierDto> createSupplierValidator,
            IValidator<UpdateSupplierDto> updateSupplierValidator)
        {
            _supplierService = supplierService;
            _createSupplierValidator = createSupplierValidator;
            _updateSupplierValidator = updateSupplierValidator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SupplierDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierService.GetAllAsync();
            if (suppliers == null || !suppliers.Any())
            {
                return NotFound("No suppliers found.");
            }
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }
            return Ok(supplier);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateSupplierDto supplierDto)
        {
            ValidationResult validationResult = await _createSupplierValidator.ValidateAsync(supplierDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var createdSupplier = await _supplierService.AddSupplierAsync(supplierDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSupplier.Id }, createdSupplier);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UpdateSupplierDto updateDto)
        {
            ValidationResult validationResult = await _updateSupplierValidator.ValidateAsync(updateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var updatedSupplier = await _supplierService.UpdateSupplierAsync(id, updateDto);
            if (updatedSupplier == null)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }

            return Ok(updatedSupplier);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _supplierService.DeleteSupplierAsync(id);
            if (!deleted)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }
            return Ok(deleted);
        }
    }
}
