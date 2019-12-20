using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.FilesTests
{
    [TestFixture]
    public class GetTests : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.GetFilesDataSource))]
        public async Task GetTestAsync(string fileId)
        {
            var result = await this.BirdsApiClient.GetFileAsync(fileId, CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result.Data);
        }
        
        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.GetFilesDataSource))]
        public async Task GetFromRepoTestAsync(string fileId)
        {
            var result = await this.FilesRepository.GetAsync(fileId, CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result);
        }
    }
}
