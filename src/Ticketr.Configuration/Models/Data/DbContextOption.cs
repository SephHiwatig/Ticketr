using System.ComponentModel.DataAnnotations;

namespace Ticketr.Configuration.Models.Data
{
    public class DbContextOption
    {
        [Required]
        public ConnectionString? ConnectionString { get; set; }
        [Required]
        public Password? Password { get; set; }
    }
}
