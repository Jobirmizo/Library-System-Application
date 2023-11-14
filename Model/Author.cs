using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
