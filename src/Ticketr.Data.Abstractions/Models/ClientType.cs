using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ClientType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string? Description { get; set; }

        public ICollection<Client>? Clients { get; set; }
    }
}
