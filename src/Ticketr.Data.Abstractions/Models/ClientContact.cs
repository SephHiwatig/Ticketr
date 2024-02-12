using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class ClientContact
    {
        public int ClientId { get; set; }

        public Guid ApplicationUserId { get; set; }

        public Client? Client { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public static readonly Action<EntityTypeBuilder<ClientContact>> DatabaseDefinition = entity =>
        {
            entity.HasKey(clientContact => new { clientContact.ClientId, clientContact.ApplicationUserId });

            entity.HasOne(clientContact => clientContact.Client)
                  .WithMany(client => client.ClientContacts)
                  .HasForeignKey(clientContact => clientContact.ClientId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
