using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Birds.ClientModels.Birds
{
    [DataContract]
    public sealed class BatchBirdsBuildInfo
    {
        [DataMember(IsRequired = true)]
        public IReadOnlyList<BirdBuildInfo> Items { get; set; }
    }
}