using Moq;

namespace PlayerManager.Tests;

[TestFixture]
public class PlayerServiceTests
{
    [Test]
    public void RegisterPlayer_WhenPlayerDoesNotExist_AddsPlayer()
    {
        var repository = new Mock<IPlayerRepository>();
        repository.Setup(r => r.Exists("alice")).Returns(false);

        var service = new PlayerService(repository.Object);

        var result = service.RegisterPlayer("alice");

        Assert.That(result, Is.True);
        repository.Verify(r => r.Add(It.Is<Player>(p => p.Name == "alice" && p.Score == 0)), Times.Once);
    }

    [Test]
    public void RegisterPlayer_WhenPlayerAlreadyExists_ReturnsFalse()
    {
        var repository = new Mock<IPlayerRepository>();
        repository.Setup(r => r.Exists("alice")).Returns(true);

        var service = new PlayerService(repository.Object);

        var result = service.RegisterPlayer("alice");

        Assert.That(result, Is.False);
        repository.Verify(r => r.Add(It.IsAny<Player>()), Times.Never);
    }
}
