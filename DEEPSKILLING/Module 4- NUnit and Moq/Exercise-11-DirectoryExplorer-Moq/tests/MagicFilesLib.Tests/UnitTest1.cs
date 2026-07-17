using Moq;

namespace MagicFilesLib.Tests;

[TestFixture]
public class DirectoryExplorerTests
{
    [Test]
    public void GetFiles_WhenDirectoryIsProvided_ReturnsFilesFromReader()
    {
        var directoryReader = new Mock<IDirectoryReader>();
        directoryReader.Setup(reader => reader.GetFiles("/tmp"))
            .Returns(new[] { "a.txt", "b.txt" });

        var explorer = new DirectoryExplorer(directoryReader.Object);

        var result = explorer.GetFiles("/tmp");

        Assert.That(result, Is.EqualTo(new[] { "a.txt", "b.txt" }));
        directoryReader.Verify(reader => reader.GetFiles("/tmp"), Times.Once);
    }
}
