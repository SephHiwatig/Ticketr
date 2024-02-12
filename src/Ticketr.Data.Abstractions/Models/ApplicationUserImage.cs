using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class ApplicationUserImage
    {
        public Guid ApplicationUserImageMetaDataId { get; set; }

        public byte[]? Image { get; set; }

        public ApplicationUserImageMetaData? ApplicationUserImageMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<ApplicationUserImage>> DatabaseDefinition = entity =>
        {
            entity.HasKey(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId);

            entity.Property(applicationUserImage => applicationUserImage.Image)
                  .IsRequired();

            entity.HasOne(applicationUserImage => applicationUserImage.ApplicationUserImageMetaData)
                  .WithOne(applicationUserImageMetaData => applicationUserImageMetaData.ApplicationUserImage)
                  .HasForeignKey<ApplicationUserImage>(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
