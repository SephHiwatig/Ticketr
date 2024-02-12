using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Data.Models
{
    public class TicketStatusHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid TicketId { get; set; }

        public int TicketStatusId { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public Ticket? Ticket { get; set; }
        public TicketStatus? TicketStatus { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketStatusHistory>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketStatusHistory => ticketStatusHistory.Id);

            entity.HasOne(ticketStatusHistory => ticketStatusHistory.Ticket)
                  .WithMany(ticket => ticket.TicketStatusHistories)
                  .HasForeignKey(ticketStatusHistory => ticketStatusHistory.TicketId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticketStatusHistory => ticketStatusHistory.TicketStatus)
                  .WithMany(ticketStatus => ticketStatus.TicketStatusHistories)
                  .HasForeignKey(ticketStatusHistory => ticketStatusHistory.TicketStatusId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
