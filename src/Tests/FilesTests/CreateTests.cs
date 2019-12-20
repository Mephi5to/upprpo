using System;
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
        
        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.CorrectFilesDataSource))]
        public async Task CreateInRepoTestAsync(string filePath)
        {
            var content = System.IO.File.ReadAllBytes(filePath);
            var creationInfo = new FileCreationInfo
            {
                Name = "testFile",
                Data = content,
            };
            
            var result = await this.FilesRepository.CreateAsync(creationInfo.Data, creationInfo.Name, CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(result);
        }
        
        [Test]
        public void ThrowArgumentNullExceptionTestAsync()
        {
            AsyncTestDelegate asyncDelegate = async () => await this.BirdsApiClient.CreateFileAsync(null, CancellationToken.None);
            Assert.ThrowsAsync<ArgumentNullException>(asyncDelegate);
        }
    }
}
