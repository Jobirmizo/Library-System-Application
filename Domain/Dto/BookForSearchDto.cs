using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Library_System_Application.Domain.Dto;

public class BookForSearchDto
{
  
    public byte[]? Image { get; set; }
    
  
    public int? AuthorId { get; set; }
}