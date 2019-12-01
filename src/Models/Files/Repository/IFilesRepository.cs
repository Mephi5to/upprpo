using System.Threading;
using System.Threading.Tasks;

namespace Birds.Models.Files.Repository
{
    public interface IFilesRepository
    {
        Task<string> CreateAsync(byte[] imageBytes, string fileName, CancellationToken token);

        Task<byte[]> GetAsync(string id, CancellationToken token);

        Task RemoveAsync(string id, CancellationToken token);
    }
}