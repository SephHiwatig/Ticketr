using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class TicketNoteAttachment
    {
        [Key]
        public int TicketNoteAttachmentMetaDataId { get; set; }

        [Required]
        public byte[]? File { get; set; }

        public TicketNoteAttachmentMetaData? TicketNoteAttachmentMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketNoteAttachment>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaDataId);

            entity.HasOne(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaData)
                  .WithOne(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteAttachment)
                  .HasForeignKey<TicketNoteAttachment>(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaDataId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
