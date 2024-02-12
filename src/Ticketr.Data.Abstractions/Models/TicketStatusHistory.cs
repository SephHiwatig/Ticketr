using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class TicketStatusHistory
    {
        public int Id { get; set; }

        public Guid TicketId { get; set; }

        public int TicketStatusId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public Ticket? Ticket { get; set; }
        public TicketStatus? TicketStatus { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketStatusHistory>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketStatusHistory => ticketStatusHistory.Id);

            entity.Property(ticketStatusHistory => ticketStatusHistory.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(ticketStatusHistory => ticketStatusHistory.CreatedBy)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(ticketStatusHistory => ticketStatusHistory.Ticket)
                  .WithMany(ticket => ticket.TicketStatusHistories)
                  .HasForeignKey(ticketStatusHistory => ticketStatusHistory.TicketId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticketStatusHistory => ticketStatusHistory.TicketStatus)
                  .WithMany(ticketStatus => ticketStatus.TicketStatusHistories)
                  .HasForeignKey(ticketStatusHistory => ticketStatusHistory.TicketStatusId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
