using CRUD_API.DTOs.CategoryDTOs;
using CRUD_API.Models;

namespace CRUD_API.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<CategoryDto?> GetCategoryByNameAsync(string name);
        Task<CategoryDto> AddCategoryAsync(CreateCategoryDto category);
        Task<CategoryDto?> UpdateCategoryAsync(int id ,UpdateCategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
