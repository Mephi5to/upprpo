using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Birds.ClientModels.Files
{
    [DataContract]
    public sealed class FileCreationInfo
    {
        [DataMember(IsRequired = true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        [DataMember(IsRequired =  true)]
        public byte[] Data { get; set; }
    }
}