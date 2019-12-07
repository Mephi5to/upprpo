using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Birds.ClientModels.Birds
{
    [DataContract]
    public sealed class BirdBuildInfo
    {
        [DataMember(IsRequired = true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        [DataMember(IsRequired = true)]
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        
        [DataMember(IsRequired = true)]
        [Required(AllowEmptyStrings = false)]
        public string AudioFileId { get; set; }
        
        [DataMember(IsRequired = true)]
        [Required(AllowEmptyStrings = false)]
        public string ImageFileId { get; set; }
    }
}