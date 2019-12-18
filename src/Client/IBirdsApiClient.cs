using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using ClientBirdsModels = Birds.ClientModels.Birds;
using ClientFilesModels = Birds.ClientModels.Files;

namespace Client
{
    public interface IBirdsApiClient
    {
        Task<BirdsList> SearchBirdsAsync(ClientBirdsModels.BirdsSearchQuery query, CancellationToken token);
        
        Task<BirdsList> CreateBatchBirdsAsync(ClientBirdsModels.BatchBirdsBuildInfo batchBuildInfo, CancellationToken token);
        
        Task<ClientFilesModels.FileCreationResultInfo> CreateFileAsync(ClientFilesModels.FileCreationInfo creationInfo, CancellationToken token);
        
        Task<ClientFilesModels.File> GetFileAsync(string id, CancellationToken token);
    }
}