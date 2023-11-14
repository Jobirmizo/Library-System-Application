using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library_System_Application.Model;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string PublicationYear { get; set; } = null!;

    public string Language { get; set; } = null!;
  
    public int CategoryId { get; set; }

    public int CopiesOwned { get; set; }
    [JsonIgnore]
    public virtual Category Category { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
