using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ticketr.Data.Models;

namespace Ticketr.Data.DbContext
{
    public class TicketrDbContext(DbContextOptions<TicketrDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
    {
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserImage> ApplicationUserImage { get; set; }
        public DbSet<ApplicationUserImageMetaData> ApplicationUserImageMetaData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(applicationUser => applicationUser.Id);
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

            builder.Entity<ApplicationUserImage>(entity =>
            {
                entity.HasKey(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId);

                entity.HasOne(applicationUserImage => applicationUserImage.ApplicationUserImageMetaData)
                      .WithOne(applicationUserImageMetaData => applicationUserImageMetaData.ApplicationUserImage)
                      .HasForeignKey<ApplicationUserImage>(applicationUserImage => applicationUserImage.ApplicationUserImageMetaDataId)
                      .IsRequired(true)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
