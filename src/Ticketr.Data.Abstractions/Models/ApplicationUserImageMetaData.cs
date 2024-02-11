using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ApplicationUserImageMetaData
    {
        [Key]
        public Guid AppilcationUserId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? ContentType { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public ApplicationUserImage? ApplicationUserImage { get; set; }
    }
}
