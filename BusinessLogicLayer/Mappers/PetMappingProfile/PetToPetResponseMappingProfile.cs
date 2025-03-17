using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers.PetMappingProfile;

public class PetToPetResponseMappingProfile : Profile
{
    public PetToPetResponseMappingProfile()
    {
        CreateMap<Pet, PetResponse>()
            .ForMember(dest => dest.PetOwnerName,
                opt => opt.MapFrom(src => src.PetOwner.UserName))
            .ForMember(dest => dest.BookingCount,
                opt => opt.MapFrom(src => src.Bookings.Count));
    }
}