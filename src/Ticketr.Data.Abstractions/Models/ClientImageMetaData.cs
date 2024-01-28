using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ClientImageMetaData
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ContentType { get; set; }

        public Client? Client { get; set; }
        public ClientImage? ClientImage { get; set; }
    }
}
