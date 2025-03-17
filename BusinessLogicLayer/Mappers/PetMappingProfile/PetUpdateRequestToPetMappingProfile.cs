using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers.PetMappingProfile;

public class PetUpdateRequestToPetMappingProfile : Profile
{
    public PetUpdateRequestToPetMappingProfile()
    {
        CreateMap<PetUpdateRequest, Pet>()
            .ForMember(dest => dest.PetOwnerID, opt => opt.Ignore()) 
            .ForMember(dest => dest.PetOwner, opt => opt.Ignore())   
            .ForMember(dest => dest.Bookings, opt => opt.Ignore());
    }
}
