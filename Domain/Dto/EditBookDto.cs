namespace Library_System_Application.Domain.Dto;

public class EditBookDto
{
    public string? Title { get; set; } = null!;

    public string? PublicationYear { get; set; }

    public string? Language { get; set; }

    public int? CategoryId { get; set; }

    public int? CopiesOwned { get; set; }

    public int? Count { get; set; }
    
    public int? AuthorId { get; set; }
}