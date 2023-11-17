using AutoMapper;

namespace Library_System_Application.Domain.Mapping;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        CreateMap<BookController, BookUpload>();
    }
    
}