namespace AccountsManager;

public class AccountsManager
{
    private static readonly IReadOnlyDictionary<string, string> ValidUsers = new Dictionary<string, string>
    {
        ["user_1"] = "secret@user11",
        ["user_2"] = "secret@user22"
    };

    public string Login(string? userId, string? password)
    {
        if (userId is null)
        {
            throw new ArgumentException("User id cannot be null.", nameof(userId));
        }

        if (password is null)
        {
            throw new ArgumentException("Password cannot be null.", nameof(password));
        }

        return ValidUsers.TryGetValue(userId, out string? expectedPassword) && expectedPassword == password
            ? "Welcome user!!!"
            : "Invalid user id/password";
    }
}
