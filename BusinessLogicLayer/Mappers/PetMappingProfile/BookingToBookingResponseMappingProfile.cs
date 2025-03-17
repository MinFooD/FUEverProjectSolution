using AutoMapper;
using BusinessLogicLayer.Dtos.PetDtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers.PetMappingProfile;

public class BookingToBookingResponseMappingProfile : Profile
{
    public BookingToBookingResponseMappingProfile()
    {
        CreateMap<Pet, PetResponse>()
    .ForMember(d => d.bookingResponses, opt => opt.MapFrom(src => src.Bookings));
    }
}