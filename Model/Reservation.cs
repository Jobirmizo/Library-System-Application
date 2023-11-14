using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Reservation
{
    public int Id { get; set; }

    public int BooksId { get; set; }

    public int StudentId { get; set; }

    public virtual Book Books { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
