using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Birds.API.Converters;
using Birds.ClientModels.Birds;
using NUnit.Framework;
using BirdBuildInfo = Birds.Models.Birds.BirdBuildInfo;

namespace Tests.BirdsTests
{
    [TestFixture]
    public sealed class CreateTests : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.CorrectBirdsDataSource))]
        public async Task CreateTestAsync(BatchBirdsBuildInfo batchBirdsBuildInfo)
        {
            var result = await this.BirdsApiClient.CreateBatchBirdsAsync(batchBirdsBuildInfo, CancellationToken.None)
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result.Birds);
        }
        
        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.CorrectBirdsDataSource))]
        public async Task CreateWithRepoTestAsync(BatchBirdsBuildInfo batchBirdsBuildInfo)
        {
            var modelBatchBuildInfo = batchBirdsBuildInfo.Items.Select(BirdsConverter.Convert).ToList();
            var result = await this.BirdsRepository.CreateBatchAsync(modelBatchBuildInfo, CancellationToken.None)
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.IsNotEmpty(result);
        }
        
        [Test]
        public void ThrowsArgumentNullExceptionTestAsync()
        {
            AsyncTestDelegate asyncDelegate = async () => await this.BirdsRepository.CreateBatchAsync(null, CancellationToken.None);
            Assert.ThrowsAsync<ArgumentNullException>(asyncDelegate);
        }
        
        [Test]
        public async Task CreateEmptyTestAsync()
        {
            var modelBatchBuildInfo = new List<BirdBuildInfo>(0);
            var result = await this.BirdsRepository.CreateBatchAsync(modelBatchBuildInfo, CancellationToken.None)
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        [TestCaseSource(typeof(TestBase), nameof(TestBase.CorrectBirdsDataSource))]
        public void ThrowArgumentNullExceptionTestAsync(BatchBirdsBuildInfo batchBirdsBuildInfo)
        {
            AsyncTestDelegate asyncDelegate = async () => await this.BirdsApiClient.CreateBatchBirdsAsync(null, CancellationToken.None);
            Assert.ThrowsAsync<ArgumentNullException>(asyncDelegate);
        }
    }
}
