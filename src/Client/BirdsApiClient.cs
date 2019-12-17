using System.Net.Http;
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

            var result = await httpClient.PostAsync(requestUti, null, token).ConfigureAwait(false);
            result.EnsureSuccessStatusCode();

            var responseContent = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            var birdList = JsonConvert.DeserializeObject<BirdsList>(responseContent);

            return birdList;
        }

        public Task<BirdsList> CreateBatchAsync(BatchBirdsBuildInfo batchBuildInfo, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}