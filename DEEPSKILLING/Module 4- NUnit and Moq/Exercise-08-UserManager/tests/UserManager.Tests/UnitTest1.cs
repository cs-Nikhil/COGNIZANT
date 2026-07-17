namespace UserManager.Tests;

[TestFixture]
public class UserManagerTests
{
    private UserManagerService _userManager = null!;

    [SetUp]
    public void Setup()
    {
        _userManager = new UserManagerService();
    }

    [Test]
    public void RegisterUser_WhenCredentialsAreValid_ReturnsTrue()
    {
        var result = _userManager.RegisterUser("alice", "p@ssword1");

        Assert.That(result, Is.True);
    }

    [Test]
    public void RegisterUser_WhenUsernameAlreadyExists_ReturnsFalse()
    {
        _userManager.RegisterUser("alice", "p@ssword1");

        var result = _userManager.RegisterUser("alice", "another-password");

        Assert.That(result, Is.False);
    }

    [Test]
    public void ValidateUser_WhenCredentialsMatch_ReturnsTrue()
    {
        _userManager.RegisterUser("alice", "p@ssword1");

        var result = _userManager.ValidateUser("alice", "p@ssword1");

        Assert.That(result, Is.True);
    }
}
