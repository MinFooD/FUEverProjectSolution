using AutoMapper;
using BusinessLogicLayer.Dtos.CategoryDtos;
using BusinessLogicLayer.Dtos.ProductDtos;
using BusinessLogicLayer.Dtos.StoreDtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers.AutoMappingProfile;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
		CreateMap<AddProductRequestDTO, Product>().ReverseMap();
		CreateMap<StoreDTO, Store>().ReverseMap();
        CreateMap<CategoryDTO, Category>().ReverseMap();
    }
}