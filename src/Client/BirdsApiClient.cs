using System.Net.Http;

namespace Client
{
    public sealed class BirdsApiClient
    {
        private readonly HttpClient httpClient;

        public BirdsApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}