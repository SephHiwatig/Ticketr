using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Data.Models
{
    public class TicketNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid TicketId { get; set; }

        public Guid ResourceId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Subject { get; set; }

        [Required]
        public string? Note { get; set; }

        public DateTime CreatedAt { get; set; }

        public Ticket? Ticket { get; set; }
        public ApplicationUser? Resource { get; set; }
        public TicketNoteAttachmentMetaData? TicketNoteAttachmentMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketNote>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketNote => ticketNote.Id);

            entity.HasOne(ticketNote => ticketNote.Ticket)
                  .WithMany(ticket => ticket.TicketNotes)
                  .HasForeignKey(ticketNote => ticketNote.TicketId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticketNote => ticketNote.Resource)
                  .WithMany(resource => resource.TicketNotes)
                  .HasForeignKey(ticketNote => ticketNote.ResourceId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
