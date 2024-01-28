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
    }
}
