namespace Library_System_Application.Domain.Dto;

public class StudentInfoDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? IdCard { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string? Role { get; set; }
}