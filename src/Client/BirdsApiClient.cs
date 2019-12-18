using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Birds.ClientModels.Birds;
using Birds.ClientModels.Files;
using Newtonsoft.Json;

namespace Client
{
    public sealed class BirdsApiClient : IBirdsApiClient
    {
        private const string localUri = "https://localhost:5001";
        private readonly HttpClient httpClient;
        public BirdsApiClient()
        {
            this.httpClient = new HttpClient();
        }
        
        public async Task<BirdsList> SearchBirdsAsync(BirdsSearchQuery query, CancellationToken token)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            token.ThrowIfCancellationRequested();
            
            var limit = query.Limit;
            var offset = query.Offset;
            var name = query.Name;
            
            var builder = new StringBuilder();
            builder.Append($"{localUri}/api/v1/birds?{nameof(limit)}={limit}&{nameof(offset)}={offset}&");

            if (name != null)
            {
                builder.Append($"{nameof(name)}={name}");
            }

            var requestUti = builder.ToString();

            var searchResult = await httpClient.GetAsync(requestUti, token).ConfigureAwait(false);
            searchResult.EnsureSuccessStatusCode();

            var responseContent = await searchResult.Content.ReadAsStringAsync().ConfigureAwait(false);
            var birdList = JsonConvert.DeserializeObject<BirdsList>(responseContent);

            return birdList;
        }

        public async Task<BirdsList> CreateBatchBirdsAsync(BatchBirdsBuildInfo batchBuildInfo, CancellationToken token)
        {
            if (batchBuildInfo == null)
            {
                throw new ArgumentException(nameof(batchBuildInfo));
            }
            
            token.ThrowIfCancellationRequested();

            var content = JsonConvert.SerializeObject(batchBuildInfo);
            var requestContent = new StringContent(content);
            var requestUri = $"{localUri}/api/v1/birds";
            var createResult = await httpClient.PostAsync(requestUri, requestContent, token).ConfigureAwait(false);
            createResult.EnsureSuccessStatusCode();
            
            var responseContent = await createResult.Content.ReadAsStringAsync().ConfigureAwait(false);
            var birdList = JsonConvert.DeserializeObject<BirdsList>(responseContent);

            return birdList;
        }

        public async Task<FileCreationResultInfo> CreateFileAsync(FileCreationInfo creationInfo, CancellationToken token)
        {
            if (creationInfo == null)
            {
                throw new ArgumentException(nameof(creationInfo));
            }
            
            token.ThrowIfCancellationRequested();

            var content = JsonConvert.SerializeObject(creationInfo);
            var requestContent = new StringContent(content);
            var requestUri = $"{localUri}/api/v1/files";
            var createResult = await httpClient.PostAsync(requestUri, requestContent, token).ConfigureAwait(false);
            createResult.EnsureSuccessStatusCode();
            
            var responseContent = await createResult.Content.ReadAsStringAsync().ConfigureAwait(false);
            var fileCreationResultInfo = JsonConvert.DeserializeObject<FileCreationResultInfo>(responseContent);

            return fileCreationResultInfo;
        }

        public async Task<File> GetFileAsync(string id, CancellationToken token)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id));
            }

            var requestUri = $"{localUri}/api/v1/files";

            var getResult = await httpClient.GetAsync(requestUri, token).ConfigureAwait(false);
            getResult.EnsureSuccessStatusCode();

            var responseContent = await getResult.Content.ReadAsStringAsync().ConfigureAwait(false);
            var file = JsonConvert.DeserializeObject<File>(responseContent);

            return file;
        }
    }
}