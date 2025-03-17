using AutoMapper;
using BusinessLogicLayer.Dtos.BookingDtos;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappers.BookingMappingProfile;

public class BookingToBookingResponseMappingProfile : Profile
{
    public BookingToBookingResponseMappingProfile()
    {
        CreateMap<Booking, BookingResponse>();
    }
}