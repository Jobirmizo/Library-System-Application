using AutoMapper;
using Library_System_Application.Domain.Dto;
using Library_System_Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Library_System_Application.controller;
[Route("api/[controller]")]
[ApiController]
public class OrderBookController : Controller
{
    private readonly IMapper _mapper;
    private readonly LibrarySystemContext _context;
    public OrderBookController(LibrarySystemContext context, IMapper mapper)
    {
          
        _mapper = mapper;
        _context = context;
    }
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    // {
    //     
    //
    //     if (_context.Books == null)
    //     {
    //         return NotFound();
    //     }
    //     return await _context.Books.ToListAsync();
    // }
}