namespace ClientModels.Errors
{
    public static class ServiceErrorCodes
    {
        public const string System = "system";

        public const string NotFound = "not-found";

        public const string Forbidden = "auth:forbidden";

        public const string Unauthorized = "auth:unauthorized";

        public const string InvalidCredentials = "auth:invalid-credentials";

        public const string BadRequest = "bad-request";

        public const string ValidationError = "validation:error";
        
        public const string Conflict = "conflict:error";
    }
}
