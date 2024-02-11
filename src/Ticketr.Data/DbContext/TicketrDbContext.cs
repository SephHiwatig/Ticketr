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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

                ClientType[] values =
                [
                    new ClientType { Id = (int)TypeOfClient.Individual, Description = TypeOfClient.Individual.ToString() },
                    new ClientType { Id = (int)TypeOfClient.Company, Description = TypeOfClient.Company.ToString() }
                ];

                entity.HasData(values);
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
        }
    }
}
