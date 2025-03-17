using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using DataAccessLayer.Entities;
namespace BusinessLogicLayer.Mappers.PetMappingProfile;

public class PetAddRequestToPetMappingProfile : Profile
{
    public PetAddRequestToPetMappingProfile()
    {
        CreateMap<PetAddRequest, Pet>()
            .ForMember(dest => dest.PetID, opt => opt.Ignore()) 
            .ForMember(dest => dest.Bookings, opt => opt.Ignore());
    }
}
