using AutoMapper;
using Library_System_Application.Domain.Dto;
using Library_System_Application.Model;

namespace Library_System_Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<EditBookDto, Book>();
        CreateMap<Book, EditBookDto>();
        CreateMap<BookForStudentDto, Reservation>();
        CreateMap<Student, StudentInfoDto>();
        CreateMap<ReservationDto, Reservation>();
        CreateMap<Reservation, ReservationDto>();
    }
}