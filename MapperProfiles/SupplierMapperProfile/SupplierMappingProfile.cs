using AutoMapper;
using CRUD_API.DTOs.SupplierDTOs;
using CRUD_API.Models;

namespace CRUD_API.MapperProfiles.SupplierMapperProfile
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();
        }
    }
}
