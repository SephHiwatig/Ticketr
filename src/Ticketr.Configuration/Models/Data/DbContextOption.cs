using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Configuration.Models.Data
{
    public class DbContextOption
    {
        public const string SectionName = "DbContext";

        [Required]
        [ValidateObjectMembers]
        public ConnectionString? ConnectionString { get; set; }

        [Required]
        [ValidateObjectMembers]
        public Password? Password { get; set; }
    }
}
