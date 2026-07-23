using System.ComponentModel.DataAnnotations;

namespace Lab04_Token_Expiry_Handling.Models;

public sealed class LoginModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
