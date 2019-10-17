using NUnit.Framework;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
             
            _fileReader.SetUp(fr => from.Read("video.txt")).Rrturns("");
              var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

    }
}