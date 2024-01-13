using System.ComponentModel.DataAnnotations;

namespace Ticketr.Configuration.Models.Data
{
    public class ConnectionString
    {
        [Required]
        internal string? Ticketr { get; set; }
    }
}
