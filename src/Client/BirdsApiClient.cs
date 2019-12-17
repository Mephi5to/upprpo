using System.Net.Http;

namespace Client
{
    public sealed class BirdsApiClient : IBirdsApiClient
    {
        private readonly HttpClient httpClient;

        public BirdsApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public 
    }
}