using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        public int ClientTypeId { get; set; }

        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public ClientType? ClientType { get; set; }
        public ClientImageMetaData? ClientImageMetaData { get; set; }

        public ICollection<ClientContact>? ClientContacts { get; set; }
        public ICollection<Project>? Projects { get; set; }

        public static readonly Action<EntityTypeBuilder<Client>> DatabaseDefinition = entity =>
        {
            entity.HasKey(client => client.Id);

            entity.Property(client => client.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(client => client.Name)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.HasOne(client => client.ClientType)
                  .WithMany(clientType => clientType.Clients)
                  .HasForeignKey(client => client.ClientTypeId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
