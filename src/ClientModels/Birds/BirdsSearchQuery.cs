using System.ComponentModel.DataAnnotations;

namespace Birds.ClientModels.Birds
{
    public sealed class BirdsSearchQuery
    {
        [Range(0, int.MaxValue)]
        public int Offset { get; set; }
        
        [Range(0, 1000)]
        public int Limit { get; set; }
        
        public string Name { get; set; }
    }
}