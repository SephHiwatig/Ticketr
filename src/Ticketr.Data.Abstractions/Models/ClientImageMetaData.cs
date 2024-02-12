using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class ClientImageMetaData
    {
        public int ClientId { get; set; }

        public string? Name { get; set; }

        public string? ContentType { get; set; }

        public Client? Client { get; set; }
        public ClientImage? ClientImage { get; set; }

        public static readonly Action<EntityTypeBuilder<ClientImageMetaData>> DatabaseDefinition = entity =>
        {
            entity.HasKey(clientImageMetaData => clientImageMetaData.ClientId);

            entity.Property(clientImageMetaData => clientImageMetaData.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(clientImageMetaData => clientImageMetaData.ContentType)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(clientImageMetaData => clientImageMetaData.Client)
                  .WithOne(client => client.ClientImageMetaData)
                  .HasForeignKey<ClientImageMetaData>(clientImageMetaData => clientImageMetaData.ClientId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
