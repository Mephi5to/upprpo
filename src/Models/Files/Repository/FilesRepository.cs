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
        
        public async Task<string> CreateAsync(byte[] data, string fileName, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var fileId = await files.UploadFromBytesAsync(fileName, data, null, token).ConfigureAwait(false);

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
    }
}