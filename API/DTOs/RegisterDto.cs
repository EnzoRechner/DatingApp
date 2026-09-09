using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public string DisplayName { get; set; } = string.Empty;
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [MinLength(4)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
