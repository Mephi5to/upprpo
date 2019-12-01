using System.Collections.Generic;

namespace ClientModels.Birds
{
    public sealed class BatchBirdsBuildInfo
    {
        private IReadOnlyList<BirdBuildInfo> Items { get; set; }
    }
}