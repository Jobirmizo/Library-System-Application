namespace Library_System_Application.Domain.Dto;

public class OrderBookDto
{
    public byte[]? Image { get; set; }
    public string Title { get; set; } = null!;
    public int? AuthorId { get; set; }
}