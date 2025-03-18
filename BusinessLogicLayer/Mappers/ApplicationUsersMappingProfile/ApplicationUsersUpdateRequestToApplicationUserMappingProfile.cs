using AutoMapper;
using BusinessLogicLayer.Dtos.ApplicationUsersDtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers.ApplicationUsersMappingProfile;

public class ApplicationUsersUpdateRequestToApplicationUserMappingProfile : Profile
{
    public ApplicationUsersUpdateRequestToApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUsersUpdateRequest, ApplicationUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName ?? string.Empty))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email ?? string.Empty))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.RegistrationDate, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.StoreId, opt => opt.Ignore());
    }
}
