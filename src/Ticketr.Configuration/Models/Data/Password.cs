using System.ComponentModel.DataAnnotations;

namespace Ticketr.Configuration.Models.Data
{
    public class Password
    {
        [Required]
        public bool RequireNonAlphanumeric { get; set; } = true;

        [Required]
        public bool RequireDigit { get; set; } = true;

        [Required]
        public bool RequireUppercase { get; set; } = true;

        [Required]
        [Range(6, 16)]
        public int RequiredLength { get; set; } = 6;

        [Required]
        [Range(1, 16)]
        public int RequiredUniqueChars { get; set; } = 1;
    }
}
