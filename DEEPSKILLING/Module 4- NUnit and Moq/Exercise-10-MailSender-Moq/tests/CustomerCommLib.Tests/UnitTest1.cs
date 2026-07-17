using Moq;

namespace CustomerCommLib.Tests;

[TestFixture]
public class MailServiceTests
{
    [Test]
    public void Send_WhenCalled_UsesEmailSender()
    {
        var emailSender = new Mock<IEmailSender>();
        emailSender.Setup(sender => sender.Send("customer@example.com", "Welcome", "Hello there"))
            .Returns(true);

        var mailService = new MailService(emailSender.Object);

        var result = mailService.Send("customer@example.com", "Welcome", "Hello there");

        Assert.That(result, Is.True);
        emailSender.Verify(sender => sender.Send("customer@example.com", "Welcome", "Hello there"), Times.Once);
    }
}
