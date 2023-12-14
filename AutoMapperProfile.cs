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
        CreateMap<BookForSearchDto, Book>();
        CreateMap<User, StudentInfoDto>();
        CreateMap<OrderBookDto, Book>();
    }
}