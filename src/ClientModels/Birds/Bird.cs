namespace Birds.ClientModels.Birds
{
    public sealed class Bird
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string AudioDataId { get; set; }
        
        public string ImageDataId { get; set; }
    }
}