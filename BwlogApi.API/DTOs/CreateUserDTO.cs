namespace BwlogApi.API.DTOs;
using System.ComponentModel.DataAnnotations;
public record CreateUserDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [MinLength(6)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$", ErrorMessage = "Password must be between 6 and 15 characters and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character.")]
    public string Password { get; set; }
}
