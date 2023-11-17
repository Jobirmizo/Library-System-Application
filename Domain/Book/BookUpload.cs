namespace Library_System_Application.Domain;

public class BookUpload
{
    public string Title { get; set; } = null!;

    public string PublicationYear { get; set; } = null!;

    public string Language { get; set; } = null!;

    public int CategoryId { get; set; }

    public int Count { get; set; }
}