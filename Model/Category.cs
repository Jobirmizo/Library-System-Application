using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library_System_Application.Model;

public partial class Category
{
  
    public int Id { get; set; }
   
    public string Name { get; set; } = null!;

    public string Category1 { get; set; } = null!;
   
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
