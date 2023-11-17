using Microsoft.AspNetCore.Mvc;

namespace Library_System_Application.Domain;

[Route("api/[controller]")]
[ApiController]
public class BookOnlyTitleController
{
    
    private readonly LibrarySystemContext _context;
    public BookOnlyTitleController(LibrarySystemContext context)
    {
        _context = context;
    }

       
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookOnlyTitleCount>>> GetBooks()
    {
        return await _context.Books.Select(x=> new BookOnlyTitleCount { Title   = x.Title, Count = x.Count }).ToListAsync();
    }
}