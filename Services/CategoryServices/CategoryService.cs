using AutoMapper;
using CRUD_API.DTOs.CategoryDTOs;
using CRUD_API.Models;
using CRUD_API.Repositories.CategoryRepositories;

namespace CRUD_API.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var Categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(Categories);
        }
        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var Category = await _categoryRepository.GetCategoryByIdAsync(id);
            return Category != null ? _mapper.Map<CategoryDto>(Category) : null;
        }
        public async Task<CategoryDto?> GetCategoryByNameAsync(string name)
        {
            var Category = await _categoryRepository.GetCategoryByNameAsync(name);
            return Category != null ? _mapper.Map<CategoryDto>(Category) : null;
        }
        public async Task<CategoryDto> AddCategoryAsync(CreateCategoryDto category)
        {
            var cat = _mapper.Map<Category>(category);    
            var categorydto = await _categoryRepository.AddCategoryAsync(cat);
            return _mapper.Map<CategoryDto>(categorydto);
        }
        public async Task<CategoryDto?> UpdateCategoryAsync(int id, UpdateCategoryDto category)
        {
            var cat = await _categoryRepository.GetCategoryByIdAsync(id);
            if(cat == null)
            {
                _logger.LogWarning($"Category with id {id} not found.");
                return null;
            }
            _mapper.Map(category, cat);
            var Categorydto = await _categoryRepository.UpdateCategoryAsync(cat);
            return _mapper.Map<CategoryDto>(Categorydto);
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var cat = await _categoryRepository.GetCategoryByIdAsync(id);
            if (cat == null)
            {
                _logger.LogWarning($"Category with id {id} not found.");
                return false;
            }
            await _categoryRepository.DeleteCategoryAsync(cat);
            return true;
        }
    }
}
