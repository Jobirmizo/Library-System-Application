using System.Text.Json;
using AutoMapper;
using Library_System_Application.Model;
using Microsoft.AspNetCore.Mvc;
using Library_System_Application.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library_System_Application.Domain;

[Route("api/[controller]")]
[ApiController]

public class BookOnlyTitleCount : ControllerBase
{
    
    private readonly LibrarySystemContext _context;

    public BookOnlyTitleCount(LibrarySystemContext context)
    {
        _context = context;
    }
   
    [HttpPost("add-book")]
    public IActionResult AddSingleBook([FromBody] BookOnlyModel book)
    {
        var _book = new Book()
        {
            Title = book.Title,
            PublicationYear = book.PublicationYear,
            Language = book.Language,
            CategoryId = book.CategoryId,
            AuthorId = book.AuthorId,
            Count = book.Count,
        };
        _context.Books.Add(_book);
        _context.SaveChanges();

        return Ok();
    }
    

}