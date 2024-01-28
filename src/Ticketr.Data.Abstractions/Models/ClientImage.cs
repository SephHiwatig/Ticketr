using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ClientImage
    {
        [Key]
        public int ClientImageMetaDataId { get; set; }

        [Required]
        public byte[]? Image { get; set; }

        public ClientImageMetaData? ClientImageMetaData { get; set; }
    }
}
