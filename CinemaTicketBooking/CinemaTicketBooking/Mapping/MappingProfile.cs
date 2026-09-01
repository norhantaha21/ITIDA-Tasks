using AutoMapper;
using CinemaTicketBooking.Dtos.AudiotoriumDtos;
using CinemaTicketBooking.Dtos.BookingDtos;
using CinemaTicketBooking.Dtos.CustomerDtos;
using CinemaTicketBooking.Dtos.MovieDtos;
using CinemaTicketBooking.Dtos.ShowTimeDtos;
using CinemaTicketBooking.Models;

namespace CinemaTicketBooking.Mapping
{
    public class MappingProfile:Profile   
    {
        public MappingProfile() {
            CreateMap<Movie, MovieV1Dto>();
            CreateMap<Movie, MovieV2Dto>();
            CreateMap<CreateUpdateMovieDto, Movie>();

            CreateMap<Booking, BookingResponseDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.ShowTime.Movie.Name))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.ShowTime.Auditorium.RoomNumber))
                .ForMember(dest => dest.ShowTime, opt => opt.MapFrom(src => src.ShowTime.StartTime));

            CreateMap<Auditorium, AuditoriumDto>();
            CreateMap<CreateUpdateAuditoriumDto, Auditorium>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<ShowTime, ShowTimeResponseDto>()
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
            .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Auditorium.RoomNumber))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Auditorium.Capacity));

            CreateMap<CreateUpdateShowTimeDto, ShowTime>();
        }
    }
}
