using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Files;
using NUnit.Framework;

namespace Tests.FilesTests
{
    [TestFixture]
    public sealed class CreateTests : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.CorrectFilesDataSource))]
        public async Task CreateTestAsync(string filePath)
        {
            var content = System.IO.File.ReadAllBytes(filePath);
            var creationInfo = new FileCreationInfo
            {
                Name = "testFile",
                Data = content,
            };
            
            var result = await this.BirdsApiClient.CreateFileAsync(creationInfo, CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(result);
        }
    }
}
