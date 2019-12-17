using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using ClientModels = Birds.ClientModels.Birds;

namespace Client
{
    public interface IBirdsApiClient
    {
        Task<BirdsList> SearchRequestsAsync(ClientModels.BirdsSearchQuery query, CancellationToken token);
        
        Task<BirdsList> CreateBatchAsync(ClientModels.BatchBirdsBuildInfo batchBuildInfo, CancellationToken token);
    }
}