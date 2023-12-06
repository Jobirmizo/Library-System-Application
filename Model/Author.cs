using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
