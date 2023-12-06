using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string PublicationYear { get; set; } = null!;

    public string Language { get; set; } = null!;

    public int CategoryId { get; set; }

    public int CopiesOwned { get; set; }

    public int? Count { get; set; }

    public byte[]? Image { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
