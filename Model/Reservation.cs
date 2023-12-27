using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library_System_Application.Model;

public partial class Reservation
{
    public int Id { get; set; }

    public int BooksId { get; set; }

    public int StudentId { get; set; }

    public string BorrowDate { get; set; }

    public string ReturnDate { get; set; }

    [JsonIgnore] public virtual Book Books { get; set; } = null!;

    [JsonIgnore] public virtual Student Student { get; set; } = null!;
}
