using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int TicketPriorityId { get; set; }

        public int ProjectId { get; set; }

        public Guid? PrimaryResourceId { get; set; }

        public int EstimatedTimeInHours { get; set; }

        public int EstimatedTimeInMinutes { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public TicketPriority? TicketPriority { get; set; }
        public Project? Project { get; set; }
        public ApplicationUser? PrimaryResource { get; set; }

        public ICollection<TicketSecondaryResource>? TicketSecondaryResources { get; set; }
        public ICollection<TicketStatusHistory>? TicketStatusHistories { get; set; }
        public ICollection<TicketNote>? TicketNotes { get; set; }
        public ICollection<TicketWork>? TicketWorks { get; set; }

        public static readonly Action<EntityTypeBuilder<Ticket>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticket => ticket.Id);

            entity.Property(ticket => ticket.Title)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(ticket => ticket.Description)
                  .IsRequired();

            entity.ToTable(table =>
                  {
                      table.HasCheckConstraint($"ck_{nameof(Ticket)}_{nameof(EstimatedTimeInHours)}", $"{nameof(EstimatedTimeInHours)} BETWEEN 0 AND {int.MaxValue}");
                      table.HasCheckConstraint($"ck_{nameof(Ticket)}_{nameof(EstimatedTimeInMinutes)}", $"{nameof(EstimatedTimeInMinutes)} BETWEEN 0 AND 59");
                  });

            entity.Property(ticket => ticket.CreatedBy)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.HasOne(ticket => ticket.TicketPriority)
                  .WithMany(ticketPriority => ticketPriority.Tickets)
                  .HasForeignKey(ticket => ticket.TicketPriorityId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticket => ticket.Project)
                  .WithMany(project => project.Tickets)
                  .HasForeignKey(ticket => ticket.ProjectId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticket => ticket.PrimaryResource)
                  .WithMany(primaryResource => primaryResource.Tickets)
                  .HasForeignKey(ticket => ticket.PrimaryResourceId)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
