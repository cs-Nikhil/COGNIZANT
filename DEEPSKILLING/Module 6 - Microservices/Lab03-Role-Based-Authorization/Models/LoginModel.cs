using System.ComponentModel.DataAnnotations;

namespace Lab03_Role_Based_Authorization.Models;

public sealed class LoginModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
