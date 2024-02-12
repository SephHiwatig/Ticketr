using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketr.Data.Enums;

namespace Ticketr.Data.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public override Guid Id { get; set; }

        public static readonly Action<EntityTypeBuilder<ApplicationRole>> DatabaseDefinition = entity =>
        {
            entity.HasKey(applicationRole => applicationRole.Id);

            ApplicationRole[] applicationRoles =
            [
                new() { Id = Guid.NewGuid(), Name = TypeOfRoles.Admin.ToString(), NormalizedName = TypeOfRoles.Admin.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                new() { Id = Guid.NewGuid(), Name = TypeOfRoles.Resource.ToString(), NormalizedName = TypeOfRoles.Resource.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
                new() { Id = Guid.NewGuid(), Name = TypeOfRoles.Client.ToString(), NormalizedName = TypeOfRoles.Client.ToString().ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() },
            ];

            entity.HasData(applicationRoles);
        };
    }
}
