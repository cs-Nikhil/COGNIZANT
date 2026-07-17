namespace AccountsManager.Tests;

[TestFixture]
public class AccountsManagerTests
{
    private AccountsManager.AccountsManager _accountsManager = null!;

    [SetUp]
    public void SetUp()
    {
        _accountsManager = new AccountsManager.AccountsManager();
    }

    [TearDown]
    public void TearDown()
    {
        _accountsManager = null!;
    }

    [TestCase("user_1", "secret@user11")]
    [TestCase("user_2", "secret@user22")]
    public void Login_WhenCredentialsAreValid_ReturnsWelcomeMessage(string userId, string password)
    {
        var result = _accountsManager.Login(userId, password);

        Assert.That(result, Is.EqualTo("Welcome user!!!"));
    }

    [TestCase("user_1", "wrong-password")]
    [TestCase("invalid", "secret@user11")]
    public void Login_WhenCredentialsAreInvalid_ReturnsInvalidMessage(string userId, string password)
    {
        var result = _accountsManager.Login(userId, password);

        Assert.That(result, Is.EqualTo("Invalid user id/password"));
    }

    [Test]
    public void Login_WhenUserIdIsNull_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => _accountsManager.Login(null, "secret@user11"));

        Assert.That(exception!.ParamName, Is.EqualTo("userId"));
    }

    [Test]
    public void Login_WhenPasswordIsNull_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => _accountsManager.Login("user_1", null));

        Assert.That(exception!.ParamName, Is.EqualTo("password"));
    }
}
