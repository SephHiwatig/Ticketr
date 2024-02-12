using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticketr.Data.Enums;
using Ticketr.Data.Models;

namespace Ticketr.Data.DbContext
{
    public class TicketrDbContext(DbContextOptions<TicketrDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
    {
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserImageMetaData> ApplicationUserImageMetaData { get; set; }
        public DbSet<ApplicationUserImage> ApplicationUserImage { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<ClientImageMetaData> ClientImageMetaDatas { get; set; }
        public DbSet<ClientImage> ClientImages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketNote> TicketNotes { get; set; }
        public DbSet<TicketNoteAttachment> TicketNoteAttachments { get; set; }
        public DbSet<TicketNoteAttachmentMetaData> TicketNoteAttachmentMetaDatas { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketSecondaryResource> TicketSecondaryResources { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketStatusHistory> TicketStatusHistories { get; set; }
        public DbSet<TicketWork> TicketWorks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.HasKey(applicationRole => applicationRole.Id);

                ApplicationRole[] applicationRoles =
                [
                    new() { Id = Guid.NewGuid(), Name = TypeOfRoles.Admin.ToString(), NormalizedName = TypeOfRoles.Admin.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new() { Id = Guid.NewGuid(), Name = TypeOfRoles.Resource.ToString(), NormalizedName = TypeOfRoles.Resource.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new() { Id = Guid.NewGuid(), Name = TypeOfRoles.Client.ToString(), NormalizedName = TypeOfRoles.Client.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                ];

                entity.HasData(applicationRoles);
            });

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(applicationUser => applicationUser.Id);
            });

            builder.Entity<ApplicationUserImage>(entity =>
            {
                entity.HasKey(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId);

                entity.HasOne(applicationUserImage => applicationUserImage.ApplicationUserImageMetaData)
                      .WithOne(applicationUserImageMetaData => applicationUserImageMetaData.ApplicationUserImage)
                      .HasForeignKey<ApplicationUserImage>(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ApplicationUserImageMetaData>(entity =>
            {
                entity.HasKey(applicationUserImageMetaData => applicationUserImageMetaData.AppilcationUserId);

                entity.HasOne(applicationUserImageMetaData => applicationUserImageMetaData.ApplicationUser)
                      .WithOne(applicationUser => applicationUser.ApplicationUserImageMetaData)
                      .HasForeignKey<ApplicationUserImageMetaData>(e => e.AppilcationUserId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Client>(entity =>
            {
                entity.HasKey(client => client.Id);

                entity.HasOne(client => client.ClientType)
                      .WithMany(clientType => clientType.Clients)
                      .HasForeignKey(client => client.ClientTypeId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ClientContact>(entity =>
            {
                entity.HasKey(clientContact => new { clientContact.ClientId, clientContact.ApplicationUserId });

                entity.HasOne(clientContact => clientContact.Client)
                      .WithMany(client => client.ClientContacts)
                      .HasForeignKey(clientContact => clientContact.ClientId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ClientImage>(entity =>
            {
                entity.HasKey(clientImage => clientImage.ClientImageMetaDataId);

                entity.HasOne(clientImage => clientImage.ClientImageMetaData)
                      .WithOne(clientImageMetaData => clientImageMetaData.ClientImage)
                      .HasForeignKey<ClientImage>(clientImage => clientImage.ClientImageMetaDataId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<ClientImageMetaData>(entity =>
            {
                entity.HasKey(clientImageMetaData => clientImageMetaData.ClientId);

                entity.HasOne(clientImageMetaData => clientImageMetaData.Client)
                      .WithOne(client => client.ClientImageMetaData)
                      .HasForeignKey<ClientImageMetaData>(clientImageMetaData => clientImageMetaData.ClientId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ClientType>(entity =>
            {
                entity.HasKey(clientType => clientType.Id);

                ClientType[] clientTypes =
                [
                    new() { Id = (int)TypeOfClient.Individual, Description = TypeOfClient.Individual.ToString() },
                    new() { Id = (int)TypeOfClient.Company, Description = TypeOfClient.Company.ToString() }
                ];

                entity.HasData(clientTypes);
            });

            builder.Entity<Project>(entity =>
            {
                entity.HasKey(project => project.Id);

                entity.HasOne(project => project.Client)
                      .WithMany(client => client.Projects)
                      .HasForeignKey(project => project.ClientId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Ticket>(entity =>
            {
                entity.HasKey(ticket => ticket.Id);

                entity.HasOne(ticket => ticket.TicketPriority)
                      .WithMany(ticketPriority => ticketPriority.Tickets)
                      .HasForeignKey(ticket => ticket.TicketPriorityId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ticket => ticket.Project)
                      .WithMany(project => project.Tickets)
                      .HasForeignKey(ticket => ticket.ProjectId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ticket => ticket.PrimaryResource)
                      .WithMany(primaryResource => primaryResource.Tickets)
                      .HasForeignKey(ticket => ticket.PrimaryResourceId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TicketNote>(entity =>
            {
                entity.HasKey(ticketNote => ticketNote.Id);

                entity.HasOne(ticketNote => ticketNote.Ticket)
                      .WithMany(ticket => ticket.TicketNotes)
                      .HasForeignKey(ticketNote => ticketNote.TicketId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ticketNote => ticketNote.Resource)
                      .WithMany(resource => resource.TicketNotes)
                      .HasForeignKey(ticketNote => ticketNote.ResourceId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TicketNoteAttachment>(entity =>
            {
                entity.HasKey(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaDataId);

                entity.HasOne(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaData)
                      .WithOne(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteAttachment)
                      .HasForeignKey<TicketNoteAttachment>(ticketNoteAttachment => ticketNoteAttachment.TicketNoteAttachmentMetaDataId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TicketNoteAttachmentMetaData>(entity =>
            {
                entity.HasKey(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteId);

                entity.HasOne(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNote)
                      .WithOne(ticketNote => ticketNote.TicketNoteAttachmentMetaData)
                      .HasForeignKey<TicketNoteAttachmentMetaData>(ticketNoteAttachmentMetaData => ticketNoteAttachmentMetaData.TicketNoteId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TicketPriority>(entity =>
            {
                entity.HasKey(ticketPriority => ticketPriority.Id);

                TicketPriority[] ticketPriorities =
                [
                    new() { Id = (int)PriorityOfTicket.Low, Description = PriorityOfTicket.Low.ToString() },
                    new() { Id = (int)PriorityOfTicket.Medium, Description = PriorityOfTicket.Medium.ToString() },
                    new() { Id = (int)PriorityOfTicket.High, Description = PriorityOfTicket.High.ToString() }
                ];

                entity.HasData(ticketPriorities);
            });

            builder.Entity<TicketSecondaryResource>(entity =>
            {
                entity.HasKey(ticketSecondaryResource => new { ticketSecondaryResource.TicketId, ticketSecondaryResource.SecondaryResourceId });

                entity.HasOne(ticketSecondaryResource => ticketSecondaryResource.Ticket)
                      .WithMany(ticket => ticket.TicketSecondaryResources)
                      .HasForeignKey(ticketSecondaryResource => ticketSecondaryResource.TicketId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ticketSecondaryResource => ticketSecondaryResource.SecondaryResource)
                      .WithMany(secondaryResource => secondaryResource.TicketSecondaryResources)
                      .HasForeignKey(ticketSecondaryResource => ticketSecondaryResource.SecondaryResourceId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TicketStatus>(entity =>
            {
                entity.HasKey(ticketStatus => ticketStatus.Id);

                TicketStatus[] ticketStatuses =
                [
                    new() { Id = (int)StatusOfTicket.Unassigned, Description = StatusOfTicket.Unassigned.ToString() },
                    new() { Id = (int)StatusOfTicket.Assigned, Description = StatusOfTicket.Assigned.ToString() },
                    new() { Id = (int)StatusOfTicket.InProgress, Description = StatusOfTicket.InProgress.ToString() },
                    new() { Id = (int)StatusOfTicket.WaitingForClient, Description = StatusOfTicket.WaitingForClient.ToString() },
                    new() { Id = (int)StatusOfTicket.ClientNoteAdded, Description = StatusOfTicket.ClientNoteAdded.ToString() },
                    new() { Id = (int)StatusOfTicket.Completed, Description = StatusOfTicket.Completed.ToString() },
                    new() { Id = (int)StatusOfTicket.Reopened, Description = StatusOfTicket.Reopened.ToString() },
                    new() { Id = (int)StatusOfTicket.Abandoned, Description = StatusOfTicket.Abandoned.ToString() },
                ];

                entity.HasData(ticketStatuses);
            });

            builder.Entity<TicketStatusHistory>(entity =>
            {
                entity.HasKey(ticketStatusHistory => ticketStatusHistory.Id);

                entity.HasOne(ticketStatusHistory => ticketStatusHistory.Ticket)
                      .WithMany(ticket => ticket.TicketStatusHistories)
                      .HasForeignKey(ticketStatusHistory => ticketStatusHistory.TicketId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ticketStatusHistory => ticketStatusHistory.TicketStatus)
                      .WithMany(ticketStatus => ticketStatus.TicketStatusHistories)
                      .HasForeignKey(ticketStatusHistory => ticketStatusHistory.TicketStatusId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TicketWork>(entity =>
            {
                entity.HasKey(ticketWork => ticketWork.Id);

                entity.HasOne(ticketWork => ticketWork.Ticket)
                      .WithMany(ticket => ticket.TicketWorks)
                      .HasForeignKey(ticketWork => ticketWork.TicketId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ticketWork => ticketWork.Resource)
                      .WithMany(resource => resource.TicketWorks)
                      .HasForeignKey(ticketWork => ticketWork.ResourceId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
