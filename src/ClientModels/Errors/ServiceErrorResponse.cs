using System.Net;

namespace Birds.ClientModels.Errors
{
    public class ServiceErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        
        public ServiceError Error { get; set; }
    }
}
