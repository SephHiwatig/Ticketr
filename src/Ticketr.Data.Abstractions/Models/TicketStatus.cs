using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class TicketStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Description { get; set; }

        public ICollection<TicketStatusHistory>? TicketStatusHistories { get; set; }
    }
}
