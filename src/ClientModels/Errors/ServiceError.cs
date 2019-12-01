using System.Collections.Generic;

namespace ClientModels.Errors
{
    public class ServiceError
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Target { get; set; }

        public IDictionary<string, object> Context { get; set; }

        public ICollection<ServiceError> Errors { get; set; }
    }
}
