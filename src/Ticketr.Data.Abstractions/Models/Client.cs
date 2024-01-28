using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Data.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClientTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public ClientType? ClientType { get; set; }
        public ClientImageMetaData? ClientImageMetaData { get; set; }

        public ICollection<ClientContact>? ClientContacts { get; set; }
    }
}
