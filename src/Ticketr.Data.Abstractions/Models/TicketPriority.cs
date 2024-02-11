using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class TicketPriority
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(6)]
        public string? Description { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
