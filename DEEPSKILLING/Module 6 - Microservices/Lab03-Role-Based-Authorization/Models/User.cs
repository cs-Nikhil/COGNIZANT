namespace Lab03_Role_Based_Authorization.Models;

public sealed class User
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? Role { get; set; }
}
