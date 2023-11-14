using System;
using System.Collections.Generic;

namespace Library_System_Application.Model;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string IdCard { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public virtual ICollection<Loan> LoanBooks { get; set; } = new List<Loan>();

    public virtual ICollection<Loan> LoanStudents { get; set; } = new List<Loan>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
