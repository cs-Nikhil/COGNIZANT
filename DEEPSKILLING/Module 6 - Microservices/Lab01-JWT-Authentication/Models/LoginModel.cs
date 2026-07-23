using System.ComponentModel.DataAnnotations;

namespace Lab01_JWT_Authentication.Models;

public sealed class LoginModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
