using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using Ticketr.Data.Enums;

namespace Ticketr.Data.Models
{
    public class ClientType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string? Description { get; set; }

        public ICollection<Client>? Clients { get; set; }

        public static readonly Action<EntityTypeBuilder<ClientType>> DatabaseDefinition = entity =>
        {
            entity.HasKey(clientType => clientType.Id);

            ClientType[] clientTypes =
            [
                new() { Id = (int)TypeOfClient.Individual, Description = TypeOfClient.Individual.ToString() },
                new() { Id = (int)TypeOfClient.Company, Description = TypeOfClient.Company.ToString() }
            ];

            entity.HasData(clientTypes);
        };
    }
}
