using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Birds.Repository
{
    public interface IBirdsRepository
    {
        Task<IReadOnlyList<Bird>> SearchAsync(BirdsSearchQuery query, CancellationToken token);
        
        Task<IReadOnlyList<Bird>> CreateBatchAsync(IReadOnlyList<BirdCreationInfo> batchCreationInfos, CancellationToken token);

        Task<Bird> GetAsync(string id, CancellationToken token);

        Task RemoveAsync(string id, CancellationToken token);
    }
}