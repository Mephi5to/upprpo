using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using ClientModels = Birds.ClientModels.Files;

namespace Client.FilesClient
{
    public interface IFilesApiClient
    {
        Task<BirdsList> CreateAsync(ClientModels.FileCreationInfo creationInfo, CancellationToken token);
    }
}