using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

        public static readonly Action<EntityTypeBuilder<ApplicationUserImageMetaData>> DatabaseDefinition = entity =>
        {
            entity.HasKey(applicationUserImageMetaData => applicationUserImageMetaData.AppilcationUserId);

            entity.HasOne(applicationUserImageMetaData => applicationUserImageMetaData.ApplicationUser)
                  .WithOne(applicationUser => applicationUser.ApplicationUserImageMetaData)
                  .HasForeignKey<ApplicationUserImageMetaData>(e => e.AppilcationUserId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
