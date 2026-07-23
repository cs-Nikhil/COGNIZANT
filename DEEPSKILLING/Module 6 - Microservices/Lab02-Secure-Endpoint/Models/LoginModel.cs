using System.ComponentModel.DataAnnotations;

namespace Lab02_Secure_Endpoint.Models;

public sealed class LoginModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
