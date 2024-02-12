using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using Ticketr.Data.Enums;

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

        public static readonly Action<EntityTypeBuilder<TicketPriority>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketPriority => ticketPriority.Id);

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
