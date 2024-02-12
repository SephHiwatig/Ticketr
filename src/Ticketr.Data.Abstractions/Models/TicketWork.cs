using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketr.Data.Models
{
    public class TicketWork
    {
        public int Id { get; set; }

        public Guid TicketId { get; set; }

        public Guid ResourceId { get; set; }

        public int TimeWorkedInHours { get; set; }

        public int TimeWorkedInMinutes { get; set; }

        public DateTime DateOfWork { get; set; }

        public string? Summary { get; set; }

        public Ticket? Ticket { get; set; }
        public ApplicationUser? Resource { get; set; }

        public static readonly Action<EntityTypeBuilder<TicketWork>> DatabaseDefinition = entity =>
        {
            entity.HasKey(ticketWork => ticketWork.Id);

            entity.Property(ticketWork => ticketWork.Id)
                  .ValueGeneratedOnAdd();

            entity.ToTable(table =>
                  {
                      table.HasCheckConstraint($"ck_{nameof(TicketWork)}_{nameof(TimeWorkedInHours)}", $"{nameof(TimeWorkedInHours)} BETWEEN 0 AND {int.MaxValue}");
                      table.HasCheckConstraint($"ck_{nameof(TicketWork)}_{nameof(TimeWorkedInMinutes)}", $"{nameof(TimeWorkedInMinutes)} BETWEEN 0 AND 59");
                  });

            entity.Property(ticketWork => ticketWork.Summary)
                  .IsRequired();

            entity.HasOne(ticketWork => ticketWork.Ticket)
                  .WithMany(ticket => ticket.TicketWorks)
                  .HasForeignKey(ticketWork => ticketWork.TicketId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ticketWork => ticketWork.Resource)
                  .WithMany(resource => resource.TicketWorks)
                  .HasForeignKey(ticketWork => ticketWork.ResourceId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        };
    }
}
