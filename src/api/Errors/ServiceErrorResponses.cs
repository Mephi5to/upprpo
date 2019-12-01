using System.Net;
using ClientModels.Errors;

namespace API.Errors
{
    public static class ServiceErrorResponses
    {
        public static ServiceErrorResponse BodyIsMissing(string target)
        {
            var error = new ServiceErrorResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                Error = new ServiceError
                {
                    Code = ServiceErrorCodes.BadRequest,
                    Message = "Request body is empty or has inappropriate form.",
                    Target = target
                }
            };

            return error;
        }
    }
}
