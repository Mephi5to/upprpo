using System;

namespace Models
{
    public sealed class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message)
            : base(message)
        {
        }

        public ItemNotFoundException(string target, string resourceId)
            : base($"The resource \"{resourceId}\" of \"{target}\" is not found.")
        {
            this.Target = target;
            this.ResourceId = resourceId;
        }

        public string Target { get; }

        public string ResourceId { get; }
    }
}