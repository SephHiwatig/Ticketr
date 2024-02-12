using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class TicketNote
    {
        public int Id { get; set; }

        public Guid TicketId { get; set; }

        public Guid ResourceId { get; set; }

        public string? Subject { get; set; }

        public string? Note { get; set; }

        public DateTime CreatedAt { get; set; }

        public Ticket? Ticket { get; set; }
        public ApplicationUser? Resource { get; set; }
        public TicketNoteAttachmentMetaData? TicketNoteAttachmentMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketNote>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketNote => ticketNote.Id);

            entity.Property(ticketNote => ticketNote.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(ticketNote => ticketNote.Subject)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(ticketNote => ticketNote.Note)
                  .IsRequired();

            entity.HasOne(ticketNote => ticketNote.Ticket)
                  .WithMany(ticket => ticket.TicketNotes)
                  .HasForeignKey(ticketNote => ticketNote.TicketId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticketNote => ticketNote.Resource)
                  .WithMany(resource => resource.TicketNotes)
                  .HasForeignKey(ticketNote => ticketNote.ResourceId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
