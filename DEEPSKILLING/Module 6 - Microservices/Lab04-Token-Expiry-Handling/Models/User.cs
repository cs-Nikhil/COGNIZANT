namespace Lab04_Token_Expiry_Handling.Models;

public sealed class User
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? Role { get; set; }
}
