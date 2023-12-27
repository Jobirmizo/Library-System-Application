using AutoMapper;
using Library_System_Application.Domain.Dto;
using Library_System_Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Library_System_Application.Domain.controller;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly LibrarySystemContext _context;
    private readonly IMapper _mapper;

    public ReservationsController(LibrarySystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> PostReservation(ReservationDto reservationDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Reservation reservation = _mapper.Map<Reservation>(reservationDto);
        
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
    }



    
    
    [HttpGet("")]
    public async Task<IActionResult> GetReservation([FromQuery] int studentId)
    {
        IEnumerable<Reservation> reservations = await _context.Reservations.Where(x => x.StudentId == studentId).ToListAsync();
        
        return Ok(reservations);
    }

}