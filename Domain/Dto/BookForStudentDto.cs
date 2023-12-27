using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Library_System_Application.Domain.Dto;

public class BookForStudentDto
{
    public int BooksId { get; set; }

    public int StudentId { get; set; }
}