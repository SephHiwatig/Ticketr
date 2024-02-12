using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ApplicationUserImage
    {
        [Key]
        public Guid ApplicationUserImageMetaDataId { get; set; }

        [Required]
        public byte[]? Image { get; set; }

        public ApplicationUserImageMetaData? ApplicationUserImageMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<ApplicationUserImage>> DatabaseDefinition = entity =>
        {
            entity.HasKey(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId);

            entity.HasOne(applicationUserImage => applicationUserImage.ApplicationUserImageMetaData)
                  .WithOne(applicationUserImageMetaData => applicationUserImageMetaData.ApplicationUserImage)
                  .HasForeignKey<ApplicationUserImage>(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
