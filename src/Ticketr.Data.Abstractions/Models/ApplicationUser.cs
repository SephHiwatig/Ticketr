using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Key]
        public override Guid Id { get; set; }

        public bool IsActive { get; set; }

        public ApplicationUserImageMetaData? ApplicationUserImageMetaData { get; set; }
        
        public ICollection<ClientContact>? ClientContacts { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<TicketSecondaryResource>? TicketSecondaryResources { get; set; }
        public ICollection<TicketNote>? TicketNotes { get; set; }
        public ICollection<TicketWork>? TicketWorks { get; set; }
    }
}
