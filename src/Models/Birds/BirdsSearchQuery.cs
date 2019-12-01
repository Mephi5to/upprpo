namespace Birds.Models.Birds
{
    public sealed class BirdsSearchQuery
    {
        public int Offset { get; set; }
        
        public int Limit { get; set; }
        
        public string Name { get; set; }
    }
}