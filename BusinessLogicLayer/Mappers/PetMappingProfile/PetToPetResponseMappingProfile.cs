using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.EntityEnums;

namespace BusinessLogicLayer.Mappers.PetMappingProfile;

public class PetToPetResponseMappingProfile : Profile
{
    public PetToPetResponseMappingProfile()
    {
        CreateMap<Pet, PetResponse>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender ? "Male" : "Female"))
            .ForMember(dest => dest.PetOwnerName,
                opt => opt.MapFrom(src => src.PetOwner.UserName))
            .ForMember(dest => dest.BookingCount,
                opt => opt.MapFrom(src => src.Bookings.Count));
    }
}