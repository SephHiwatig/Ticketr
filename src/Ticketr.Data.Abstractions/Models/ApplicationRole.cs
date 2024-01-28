using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        [Key]
        public override Guid Id { get; set; }
    }
}
