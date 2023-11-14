using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Manager
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Okey { get; set; }
}
