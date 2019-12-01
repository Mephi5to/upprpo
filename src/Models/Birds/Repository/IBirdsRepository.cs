using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Birds.Models.Birds.Repository
{
    public interface IBirdsRepository
    {
        Task<IReadOnlyList<Bird>> SearchAsync(BirdsSearchQuery query, CancellationToken token);
        
        Task<IReadOnlyList<Bird>> CreateBatchAsync(IReadOnlyList<BirdBuildInfo> batchBuildInfo, CancellationToken token);

        Task<Bird> GetAsync(string id, CancellationToken token);

        Task RemoveAsync(string id, CancellationToken token);
    }
}