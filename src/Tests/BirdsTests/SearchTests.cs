using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using NUnit.Framework;
using Models = Birds.Models.Birds;

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
        
        [Test]
        public void SearchByCancelledTokenTestAsync()
        {
            var searchQuery = new Models.BirdsSearchQuery();

            AsyncTestDelegate asyncDelegate = async () => await this.BirdsRepository.SearchAsync(searchQuery, new CancellationToken(true));
            Assert.ThrowsAsync<OperationCanceledException>(asyncDelegate);
        }
        
        [Test]
        public void ThrowsArgumentNullExceptionTestAsync()
        {
            AsyncTestDelegate asyncDelegate = async () => await this.BirdsRepository.SearchAsync(null, CancellationToken.None);
            Assert.ThrowsAsync<ArgumentNullException>(asyncDelegate);
        }
        
        [Test]
        public async Task SearchWithSubstringTestAsync()
        {
            var searchQuery = new Models.BirdsSearchQuery { Name = "Ряб"};
            var result = await this.BirdsRepository.SearchAsync(searchQuery, CancellationToken.None).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.AreEqual(result.First().Name, "Рябчик");
        }
    }
}
