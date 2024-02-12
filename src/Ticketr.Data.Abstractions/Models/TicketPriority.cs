using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketr.Data.Enums;

namespace Ticketr.Data.Models
{
    public class TicketPriority
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketPriority>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketPriority => ticketPriority.Id);

            entity.Property(ticketPriority => ticketPriority.Description)
                  .IsRequired()
                  .HasMaxLength(6);

            TicketPriority[] ticketPriorities =
            [
                new() { Id = (int)PriorityOfTicket.Low, Description = PriorityOfTicket.Low.ToString() },
                new() { Id = (int)PriorityOfTicket.Medium, Description = PriorityOfTicket.Medium.ToString() },
                new() { Id = (int)PriorityOfTicket.High, Description = PriorityOfTicket.High.ToString() }
            ];

            entity.HasData(ticketPriorities);
        };
    }
}
