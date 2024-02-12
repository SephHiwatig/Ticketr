using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class TicketNoteAttachmentMetaData
    {
        public int TicketNoteId { get; set; }

        public string? Name { get; set; }

        public string? ContentType { get; set; }

        public TicketNote? TicketNote { get; set; }
        public TicketNoteAttachment? TicketNoteAttachment { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketNoteAttachmentMetaData>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteId);

            entity.Property(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.ContentType)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNote)
                  .WithOne(ticketNote => ticketNote.TicketNoteAttachmentMetaData)
                  .HasForeignKey<TicketNoteAttachmentMetaData>(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
