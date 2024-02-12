using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class TicketSecondaryResource
    {
        public Guid TicketId { get; set; }
        public Guid SecondaryResourceId { get; set; }

        public Ticket? Ticket { get; set; }
        public ApplicationUser? SecondaryResource { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketSecondaryResource>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketSecondaryResource => new { ticketSecondaryResource.TicketId, ticketSecondaryResource.SecondaryResourceId });

            entity.HasOne(ticketSecondaryResource => ticketSecondaryResource.Ticket)
                  .WithMany(ticket => ticket.TicketSecondaryResources)
                  .HasForeignKey(ticketSecondaryResource => ticketSecondaryResource.TicketId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticketSecondaryResource => ticketSecondaryResource.SecondaryResource)
                  .WithMany(secondaryResource => secondaryResource.TicketSecondaryResources)
                  .HasForeignKey(ticketSecondaryResource => ticketSecondaryResource.SecondaryResourceId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
