using System.Threading;
 using System.Threading.Tasks;
 using Birds.ClientModels.Birds;
 using NUnit.Framework;

 namespace Tests.BirdsTests
{
    [TestFixture]
    [SingleThreaded]
    [Parallelizable(ParallelScope.None)]
    public class SearchTests : TestBase
    {
        [Test]
        public async Task SearchWithLimitTestAsync()
        {
            var offset = 0;
            var limit = 2;
            var searchQuery = new BirdsSearchQuery {Limit = limit, Offset = offset};
            var result = await this.BirdsApiClient.SearchBirdsAsync(searchQuery, CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.AreEqual(limit, result.Birds.Count);
        }
    }
}
