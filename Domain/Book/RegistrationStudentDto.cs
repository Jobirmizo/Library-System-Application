using System.ComponentModel.DataAnnotations;

namespace ApiWithAuth.Controllers;
public class RegistrationRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Passport { get; set; } = null!;
}