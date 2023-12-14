using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Loan
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int BookId { get; set; }

    public DateTime? BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual User Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
