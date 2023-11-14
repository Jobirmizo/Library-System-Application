using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class BookAuthor
{
    public int BooksId { get; set; }

    public int Auithotr { get; set; }

    public virtual Author AuithotrNavigation { get; set; } = null!;

    public virtual Book Books { get; set; } = null!;
}
