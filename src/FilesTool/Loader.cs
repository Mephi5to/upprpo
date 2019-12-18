using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using Birds.ClientModels.Files;
using Client;
using Newtonsoft.Json;
using File = System.IO.File;

namespace FilesTool
{
    public sealed class Loader
    {
        private const string birdsData = "bird_data.json";

        private readonly IBirdsApiClient birdsApiClient;

        public Loader(IBirdsApiClient birdsApiClient)
        {
            this.birdsApiClient = birdsApiClient ?? throw new ArgumentNullException(nameof(birdsApiClient));
        }

        public async Task<IReadOnlyList<Bird>> UploadBirdsToServer(CancellationToken token)
        {
            var batchBuildInfo = JsonConvert.DeserializeObject<BatchBirdsBuildInfo>(File.ReadAllText(birdsData));

            var birdsList = await this.birdsApiClient.CreateBatchBirdsAsync(batchBuildInfo, token).ConfigureAwait(false);
            return birdsList.Birds;
        }

        public async Task<IReadOnlyList<string>> UploadFilesToServer(string directoryPath, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var dirInfo = new DirectoryInfo(directoryPath);
            var fileIds = new List<string>();
            
            foreach (var file in dirInfo.GetFiles())
            {
                var name = file.Name;
                var content = System.IO.File.ReadAllBytes(file.FullName);
                var fileId = await CreateFile(name, content, token).ConfigureAwait(false);
                fileIds.Add(fileId);
            }

            return fileIds;
        }

        private async Task<string> CreateFile(string fileName, byte[] content, CancellationToken token)
        {
            var creationInfo = new FileCreationInfo
            {
                Name = fileName,
                Data = content,
            };

            var creationResult = await this.birdsApiClient.CreateFileAsync(creationInfo, token).ConfigureAwait(false);
            return creationResult.Id;
        }
    }
}