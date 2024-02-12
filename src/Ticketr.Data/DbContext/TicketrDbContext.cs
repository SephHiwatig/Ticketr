using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticketr.Data.Models;

namespace Ticketr.Data.DbContext
{
    public class TicketrDbContext(DbContextOptions<TicketrDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
    {
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserImageMetaData> ApplicationUserImageMetaDatas { get; set; }
        public DbSet<ApplicationUserImage> ApplicationUserImages { get; set; }
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

            builder.Entity(ApplicationRole.DatabaseDefinition)
                   .Entity(ApplicationUser.DatabaseDefinition)
                   .Entity(ApplicationUserImage.DatabaseDefinition)
                   .Entity(ApplicationUserImageMetaData.DatabaseDefinition)
                   .Entity(Client.DatabaseDefinition)
                   .Entity(ClientContact.DatabaseDefinition)
                   .Entity(ClientImage.DatabaseDefinition)
                   .Entity(ClientImageMetaData.DatabaseDefinition)
                   .Entity(ClientType.DatabaseDefinition)
                   .Entity(Project.DatabaseDefinition)
                   .Entity(Ticket.DatabaseDefinition)
                   .Entity(TicketNote.DatabaseDefinition)
                   .Entity(TicketNoteAttachment.DatabaseDefinition)
                   .Entity(TicketNoteAttachmentMetaData.DatabaseDefinition)
                   .Entity(TicketPriority.DatabaseDefinition)
                   .Entity(TicketSecondaryResource.DatabaseDefinition)
                   .Entity(TicketStatus.DatabaseDefinition)
                   .Entity(TicketStatusHistory.DatabaseDefinition)
                   .Entity(TicketWork.DatabaseDefinition);
        }
    }
}
