using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ticketr.Data.DbContext;
using Ticketr.Data.Exceptions;

namespace Ticketr.Data.Extensions
{
    public static class IHostApplicationBuilderExtension
    {
        public static IHostApplicationBuilder UseIdentityDbContext(this IHostApplicationBuilder instance)
        {
            // TODO: Create a DbContextOption model, bind it to an instance and use it to get connection string and other info
            // such as Password options
            var connectionString = instance.Configuration.GetConnectionString("");

            if (connectionString.IsNullOrEmpty()) throw new ConnectionStringNullException();

            instance.Services.AddDbContext<TicketrDbContext>(options => options.UseSqlServer(connectionString))
                             .AddIdentityCore<IdentityUser>()
                             .AddRoles<IdentityRole>()
                             .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Ticketr")
                             .AddEntityFrameworkStores<TicketrDbContext>()
                             .AddDefaultTokenProviders();

            instance.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            });

            return instance;
        }
    }
}
