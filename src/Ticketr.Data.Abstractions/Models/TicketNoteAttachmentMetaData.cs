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
    }
}
