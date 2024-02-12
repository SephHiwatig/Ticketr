using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ClientImage
    {
        public int ClientImageMetaDataId { get; set; }

        public byte[]? Image { get; set; }

        public ClientImageMetaData? ClientImageMetaData { get; set; }

        public static readonly Action<EntityTypeBuilder<ClientImage>> DatabaseDefinition = entity =>
        {
            entity.HasKey(clientImage => clientImage.ClientImageMetaDataId);

            entity.Property(clientImage => clientImage.Image)
                  .IsRequired();

            entity.HasOne(clientImage => clientImage.ClientImageMetaData)
                  .WithOne(clientImageMetaData => clientImageMetaData.ClientImage)
                  .HasForeignKey<ClientImage>(clientImage => clientImage.ClientImageMetaDataId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
