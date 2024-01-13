using System.ComponentModel.DataAnnotations;

namespace Ticketr.Configuration.Models.Data
{
    public class ConnectionString
    {
        [Required]
        [MinLength(10)]
        public string? Ticketr { get; set; }
    }
}
