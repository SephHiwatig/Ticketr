using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Data.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int ClientId { get; set; }

        public Client? Client { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }

        public static readonly Action<EntityTypeBuilder<Project>> DatabaseDefinition = entity =>
        {
            entity.HasKey(project => project.Id);

            entity.HasOne(project => project.Client)
                  .WithMany(client => client.Projects)
                  .HasForeignKey(project => project.ClientId)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
