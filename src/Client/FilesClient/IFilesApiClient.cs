using System.Threading;
using System.Threading.Tasks;
using ClientModels = Birds.ClientModels.Files;

namespace Client.FilesClient
{
    public interface IFilesApiClient
    {
        Task<ClientModels.FileCreationResultInfo> CreateAsync(ClientModels.FileCreationInfo creationInfo, CancellationToken token);
        
        Task<ClientModels.File> GetAsync(string id, CancellationToken token);
    }
}