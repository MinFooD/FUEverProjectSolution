using AutoMapper;
using BusinessLogicLayer.Dtos.ApplicationUsersDtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers.ApplicationUsersMappingProfile;

public class ApplicationUsersToApplicationUsersResponse : Profile
{
    public ApplicationUsersToApplicationUsersResponse()
    {
        CreateMap<ApplicationUser, ApplicationUsersResponse>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName ?? string.Empty))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email ?? string.Empty));
    }
}
