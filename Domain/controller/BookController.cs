using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library_System_Application.Domain.Authentication;
using Library_System_Application.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library_System_Application.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Common;
using LibrarySystemContext = Library_System_Application.Model.LibrarySystemContext;

namespace Library_System_Application.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LibrarySystemContext _context;

        public BookController(LibrarySystemContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            if (_context.Books == null)
            {
                return NotFound();
            }

            return await _context.Books.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'LibrarySystemContext.Books'  is null.");
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] EditBookDto book)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid book ID");
            }

            // Check if the provided DTO is valid
            if (book == null)
            {
                return BadRequest("Invalid book data");
            }

            // Find the book in the database
            var existingBook = _context.Books.Find(id);

            // Check if the book exists
            if (existingBook == null)
            {
                return NotFound("Book not found");
            }

            // Use AutoMapper to map properties from EditBookDto to existingBook
            _mapper.Map(book, existingBook);

            // Save changes to the database
            _context.SaveChanges();

            return Ok("Book updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}