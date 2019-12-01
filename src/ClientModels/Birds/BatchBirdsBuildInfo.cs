using System.Collections.Generic;

namespace Birds.ClientModels.Birds
{
    public sealed class BatchBirdsBuildInfo
    {
        public IReadOnlyList<BirdBuildInfo> Items { get; set; }
    }
}