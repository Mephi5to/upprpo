using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.Birds
{
    public sealed class Bird
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public string Id { get; set; }
        
        [BsonElement("Name")]
        public string Name { get; set; }
        
        [BsonElement("Description")]
        public string Description { get; set; }
        
        [BsonElement("AudioDataId")]
        public string AudioDataId { get; set; }
        
        [BsonElement("ImageDataId")]
        public string ImageDataId { get; set; }
    }
}