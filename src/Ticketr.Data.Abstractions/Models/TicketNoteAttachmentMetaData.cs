using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class TicketNoteAttachmentMetaData
    {
        [Key]
        public int TicketNoteId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? ContentType { get; set; }

        public TicketNote? TicketNote { get; set; }
        public TicketNoteAttachment? TicketNoteAttachment { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketNoteAttachmentMetaData>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteId);

            entity.HasOne(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNote)
                  .WithOne(ticketNote => ticketNote.TicketNoteAttachmentMetaData)
                  .HasForeignKey<TicketNoteAttachmentMetaData>(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
