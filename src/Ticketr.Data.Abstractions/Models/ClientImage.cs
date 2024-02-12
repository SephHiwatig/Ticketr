using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ClientImage
    {
        [Key]
        public int ClientImageMetaDataId { get; set; }

        [Required]
        public byte[]? Image { get; set; }

        public ClientImageMetaData? ClientImageMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<ClientImage>> DatabaseDefinition = entity =>
        {
            entity.HasKey(clientImage => clientImage.ClientImageMetaDataId);

            entity.HasOne(clientImage => clientImage.ClientImageMetaData)
                  .WithOne(clientImageMetaData => clientImageMetaData.ClientImage)
                  .HasForeignKey<ClientImage>(clientImage => clientImage.ClientImageMetaDataId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
