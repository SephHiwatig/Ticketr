using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        public int TicketPriorityId { get; set; }

        public int ProjectId { get; set; }

        public Guid? PrimaryResourceId { get; set; }

        [Range(1, int.MaxValue)]
        public int EstimatedTimeInHours { get; set; }

        [Range(1, 59)]
        public int EstimatedTimeInMinutes { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public TicketPriority? TicketPriority { get; set; }
        public Project? Project { get; set; }
        public ApplicationUser? PrimaryResource { get; set; }

        public ICollection<TicketSecondaryResource>? TicketSecondaryResources { get; set; }
        public ICollection<TicketStatusHistory>? TicketStatusHistories { get; set; }
        public ICollection<TicketNote>? TicketNotes { get; set; }
        public ICollection<TicketWork>? TicketWorks { get; set; }
    }
}
