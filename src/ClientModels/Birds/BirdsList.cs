using System.Collections.Generic;

namespace Birds.ClientModels.Birds
{
    public sealed class BirdsList
    {
        public IReadOnlyList<Bird> Birds { get; set; }
    }
}