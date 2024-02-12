using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class TicketNoteAttachment
    {
        public int TicketNoteAttachmentMetaDataId { get; set; }

        public byte[]? File { get; set; }

        public TicketNoteAttachmentMetaData? TicketNoteAttachmentMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketNoteAttachment>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaDataId);

            entity.Property(ticketNoteAttachment => ticketNoteAttachment.File)
                  .IsRequired();

            entity.HasOne(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaData)
                  .WithOne(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteAttachment)
                  .HasForeignKey<TicketNoteAttachment>(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaDataId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
