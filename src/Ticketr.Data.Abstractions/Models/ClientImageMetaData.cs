using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Ticketr.Data.Models
{
    public class ClientImageMetaData
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? ContentType { get; set; }

        public Client? Client { get; set; }
        public ClientImage? ClientImage { get; set; }

        public static readonly Action<EntityTypeBuilder<ClientImageMetaData>> DatabaseDefinition = entity =>
        {
            entity.HasKey(clientImageMetaData => clientImageMetaData.ClientId);

            entity.HasOne(clientImageMetaData => clientImageMetaData.Client)
                  .WithOne(client => client.ClientImageMetaData)
                  .HasForeignKey<ClientImageMetaData>(clientImageMetaData => clientImageMetaData.ClientId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
