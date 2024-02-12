using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class ApplicationUserImageMetaData
    {
        public Guid AppilcationUserId { get; set; }

        public string? Name { get; set; }

        public string? ContentType { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public ApplicationUserImage? ApplicationUserImage { get; set; }

        public static readonly Action<EntityTypeBuilder<ApplicationUserImageMetaData>> DatabaseDefinition = entity =>
        {
            entity.HasKey(applicationUserImageMetaData => applicationUserImageMetaData.AppilcationUserId);

            entity.Property(applicationUserImageMetaData => applicationUserImageMetaData.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(applicationUserImageMetaData => applicationUserImageMetaData.ContentType)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(applicationUserImageMetaData => applicationUserImageMetaData.ApplicationUser)
                  .WithOne(applicationUser => applicationUser.ApplicationUserImageMetaData)
                  .HasForeignKey<ApplicationUserImageMetaData>(e => e.AppilcationUserId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
