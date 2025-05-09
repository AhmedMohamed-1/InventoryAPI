using AutoMapper;
using CRUD_API.DTOs.CategoryDTOs;
using CRUD_API.Models;

namespace CRUD_API.MapperProfiles.CategoryMapperProfile
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
