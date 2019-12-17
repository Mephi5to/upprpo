using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Birds.API.Controllers;
using Birds.ClientModels.Birds;
using Newtonsoft.Json;

namespace Client
{
    public sealed class BirdsApiClient : IBirdsApiClient
    {
        private readonly HttpClient httpClient;

        public BirdsApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public async Task<BirdsList> SearchRequestsAsync(BirdsSearchQuery query, CancellationToken token)
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
            builder.Append($"api/v1/birds?{nameof(limit)}={limit}&{nameof(offset)}={offset}&");

            if (name != null)
            {
                builder.Append($"{nameof(name)}={name}");
            }

            var requestUti = builder.ToString();

            var searchResult = await httpClient.PostAsync(requestUti, null, token).ConfigureAwait(false);
            searchResult.EnsureSuccessStatusCode();

            var responseContent = await searchResult.Content.ReadAsStringAsync().ConfigureAwait(false);
            var birdList = JsonConvert.DeserializeObject<BirdsList>(responseContent);

            return birdList;
        }

        public async Task<BirdsList> CreateBatchAsync(BatchBirdsBuildInfo batchBuildInfo, CancellationToken token)
        {
            if (batchBuildInfo == null)
            {
                throw new ArgumentException(nameof(batchBuildInfo));
            }
            
            token.ThrowIfCancellationRequested();

            var content = JsonConvert.SerializeObject(batchBuildInfo);
            var requestContent = new StringContent(content);
            var requestUri = "api/v1/birds";
            var createResult = await httpClient.PostAsync(requestUri, requestContent, token).ConfigureAwait(false);
            createResult.EnsureSuccessStatusCode();
            
            var responseContent = await createResult.Content.ReadAsStringAsync().ConfigureAwait(false);
            var birdList = JsonConvert.DeserializeObject<BirdsList>(responseContent);

            return birdList;
        }
    }
}