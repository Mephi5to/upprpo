using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Birds.Models.Birds
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
        
        [BsonElement("AudioFileId")]
        public string AudioFileId { get; set; }
        
        [BsonElement("ImageFileId")]
        public string ImageFileId { get; set; }
    }
}