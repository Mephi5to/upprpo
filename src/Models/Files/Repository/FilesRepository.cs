using System;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Birds.Models.Files.Repository
{
    public sealed class FilesRepository : IFilesRepository
    {
        private readonly IGridFSBucket files;

        public FilesRepository(Configuration config)
        {
            var client = new MongoClient(config.GetConnectionString("BirdsDb"));
            var database = client.GetDatabase("BirdsDb");
            this.files = new GridFSBucket(database);
        }
        
        public async Task<string> CreateAsync(byte[] imageBytes, string fileName, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            
            if (imageBytes == null)
            {
                throw new ArgumentNullException(nameof(imageBytes));
            }

            var fileId = await files.UploadFromBytesAsync(fileName, imageBytes, null, token).ConfigureAwait(false);

            return fileId.ToString();
        }

        public async Task<byte[]> GetAsync(string id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var objectId = ObjectId.Parse(id);
            var file = await files.DownloadAsBytesAsync(objectId, null, token).ConfigureAwait(false);
            
            return file;
        }

        public async Task RemoveAsync(string id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var objectId = ObjectId.Parse(id);
            await this.files.DeleteAsync(objectId, token).ConfigureAwait(false);
        }
    }
}