using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using ClientBirdsModels = Birds.ClientModels.Birds;
using ClientFilesModels = Birds.ClientModels.Files;

namespace Client
{
    public interface IBirdsApiClient
    {
        Task<BirdsList> SearchRequestsAsync(ClientBirdsModels.BirdsSearchQuery query, CancellationToken token);
        
        Task<BirdsList> CreateBatchAsync(ClientBirdsModels.BatchBirdsBuildInfo batchBuildInfo, CancellationToken token);
        
        Task<ClientFilesModels.FileCreationResultInfo> CreateAsync(ClientFilesModels.FileCreationInfo creationInfo, CancellationToken token);
        
        Task<ClientFilesModels.File> GetAsync(string id, CancellationToken token);
    }
}