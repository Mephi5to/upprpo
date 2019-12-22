using System;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using NUnit.Framework;

namespace Tests.BirdsTests
{
    [TestFixture]
    public sealed class GetTests : TestBase
    {
        [Test]
        public async Task GetTestAsync()
        {
            var result = await this.BirdsRepository.GetAsync("5dfc3fadb9694a4b1cb0109c", CancellationToken.None)
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.AreEqual(result.Name, "Рябчик");
        }

        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.CorrectBirdsDataSource))]
        public void ThrowArgumentNullExceptionTestAsync(BatchBirdsBuildInfo batchBirdsBuildInfo)
        {
            AsyncTestDelegate asyncDelegate = async () => await this.BirdsRepository.GetAsync(null, CancellationToken.None);
            Assert.ThrowsAsync<ArgumentNullException>(asyncDelegate);
        }
    }
}
