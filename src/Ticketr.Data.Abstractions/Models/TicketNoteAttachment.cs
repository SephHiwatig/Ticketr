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
    }
}
