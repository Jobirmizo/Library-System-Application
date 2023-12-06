using Library_System_Application.Model;
using Newtonsoft.Json;

namespace Library_System_Application.Domain;

public class BookOnlyModel
{
    public string Title { get; set; } = null!;

    public string PublicationYear { get; set; } = null!;

    public string Language { get; set; } = null!;
    
    public int? Count { get; set; }
    public int? AuthorId { get; set; }
    
    public int CategoryId { get; set; }
}
