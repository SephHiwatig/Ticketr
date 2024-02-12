using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketr.Data.Enums;

namespace Ticketr.Data.Models
{
    public class ClientType
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public ICollection<Client>? Clients { get; set; }

        public static readonly Action<EntityTypeBuilder<ClientType>> DatabaseDefinition = entity =>
        {
            entity.HasKey(clientType => clientType.Id);

            entity.Property(clientType => clientType.Description)
                  .IsRequired()
                  .HasMaxLength(10);

            ClientType[] clientTypes =
            [
                new() { Id = (int)TypeOfClient.Individual, Description = TypeOfClient.Individual.ToString() },
                new() { Id = (int)TypeOfClient.Company, Description = TypeOfClient.Company.ToString() }
            ];

            entity.HasData(clientTypes);
        };
    }
}
