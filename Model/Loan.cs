using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Loan
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int BookId { get; set; }

    public string? BorrowDate { get; set; }

    public string? ReturnDate { get; set; }

    public virtual Student Book { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
