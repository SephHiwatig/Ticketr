using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        public static readonly Action<EntityTypeBuilder<ApplicationUser>> DatabaseDefinition = entity => 
        {
            entity.HasKey(applicationUser => applicationUser.Id);
        };
    }
}
