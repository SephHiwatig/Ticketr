using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ApplicationUserImage
    {
        [Key]
        public Guid ApplicationUserImageMetaDataId { get; set; }

        [Required]
        public byte[]? Image { get; set; }

        public ApplicationUserImageMetaData? ApplicationUserImageMetaData { get; set; }
    }
}
