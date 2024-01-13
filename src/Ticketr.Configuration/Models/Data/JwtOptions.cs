using System.ComponentModel.DataAnnotations;

namespace Ticketr.Configuration.Models.Data
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt";

        [Required]
        [MinLength(44)]
        public string? Key { get; set; }
        [Required]
        [MinLength(13)]
        public string? Issuer { get; set; }
        [Required]
        [MinLength(13)]
        public string? Audience { get; set; }

    }
}
