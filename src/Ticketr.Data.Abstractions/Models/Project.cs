using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int ClientId { get; set; }

        public Client? Client { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }

        public static readonly Action<EntityTypeBuilder<Project>> DatabaseDefinition = entity =>
        {
            entity.HasKey(project => project.Id);

            entity.Property(project => project.Id)
                  .ValueGeneratedOnAdd();

            entity.Property(project => project.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(project => project.Description)
                  .HasMaxLength(500);

            entity.HasOne(project => project.Client)
                  .WithMany(client => client.Projects)
                  .HasForeignKey(project => project.ClientId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
