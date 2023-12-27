namespace Library_System_Application.Domain.Dto;

public class ReservationDto
{
    public int BooksId { get; set; }

    public int StudentId { get; set; }

    public string BorrowDate { get; set; }

    public string ReturnDate { get; set; } 
}