using AutoMapper;
using BusinessLogicLayer.Dtos.CategoryDtos;
using BusinessLogicLayer.Dtos.ProductDtos;
using BusinessLogicLayer.Dtos.StoreDtos;
using BusinessLogicLayer.Dtos.UserDtos;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Mappers.AutoMappingProfile;

public class AutoMapper : Profile
{
	public AutoMapper()
    {
		CreateMap<Product, ProductDTO>()
		   .ForMember(dest => dest.CategoryDtos, opt => opt.MapFrom(src => src.Category)).ReverseMap();

		CreateMap<AddProductRequestDTO, Product>().ReverseMap();
		CreateMap<UpdateProductRequestDTO, Product>().ReverseMap();
		CreateMap<StoreDTO, Store>().ReverseMap();
        CreateMap<CategoryDTO, Category>().ReverseMap();
		CreateMap<ApplicationUser, UserDtos>().ReverseMap();
	}
}