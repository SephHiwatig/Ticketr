using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Data.Models
{
    public class TicketWork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid TicketId { get; set; }

        public Guid ResourceId { get; set; }

        [Range(1, int.MaxValue)]
        public int TimeWorkedInHours { get; set; }

        [Range(1, 59)]
        public int TimeWorkedInMinutes { get; set; }

        public DateTime DateOfWork { get; set; }

        [Required]
        public string? Summary { get; set; }

        public Ticket? Ticket { get; set; }
        public ApplicationUser? Resource { get; set; }
    }
}
