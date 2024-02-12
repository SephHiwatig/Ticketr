using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using Ticketr.Data.Enums;

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

        public static readonly Action<EntityTypeBuilder<TicketStatus>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketStatus => ticketStatus.Id);

            TicketStatus[] ticketStatuses =
            [
                new() { Id = (int)StatusOfTicket.Unassigned, Description = StatusOfTicket.Unassigned.ToString() },
                new() { Id = (int)StatusOfTicket.Assigned, Description = StatusOfTicket.Assigned.ToString() },
                new() { Id = (int)StatusOfTicket.InProgress, Description = StatusOfTicket.InProgress.ToString() },
                new() { Id = (int)StatusOfTicket.WaitingForClient, Description = StatusOfTicket.WaitingForClient.ToString() },
                new() { Id = (int)StatusOfTicket.ClientNoteAdded, Description = StatusOfTicket.ClientNoteAdded.ToString() },
                new() { Id = (int)StatusOfTicket.Completed, Description = StatusOfTicket.Completed.ToString() },
                new() { Id = (int)StatusOfTicket.Reopened, Description = StatusOfTicket.Reopened.ToString() },
                new() { Id = (int)StatusOfTicket.Abandoned, Description = StatusOfTicket.Abandoned.ToString() },
            ];

            entity.HasData(ticketStatuses);
        };
    }
}
