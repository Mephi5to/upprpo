using System.Collections.Generic;

namespace ClientModels.Birds
{
    public sealed class BirdsList
    {
        public IReadOnlyList<Bird> Birds { get; set; }
    }
}