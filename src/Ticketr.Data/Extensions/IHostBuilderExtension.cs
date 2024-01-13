using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ticketr.Configuration.Models.Data;
using Ticketr.Data.DbContext;

namespace Ticketr.Data.Extensions
{
    public static class IHostBuilderExtension
    {
        public static IHostBuilder UseIdentityDbContext(this IHostBuilder instance)
        {
            instance.ConfigureServices((hostBuilderContext, services) => 
            {
                services.AddOptions<DbContextOption>()
                        .Bind(hostBuilderContext.Configuration.GetSection(DbContextOption.SectionName))
                        .ValidateDataAnnotations()
                        .ValidateOnStart();

                services.AddOptions<JwtOptions>()
                        .Bind(hostBuilderContext.Configuration.GetSection(JwtOptions.SectionName))
                        .ValidateDataAnnotations()
                        .ValidateOnStart();

                var serviceProvider = services.BuildServiceProvider();
                var dbContextOptions = serviceProvider.GetRequiredService<IOptions<DbContextOption>>().Value;

                services.AddDbContext<TicketrDbContext>(options => options.UseSqlServer(dbContextOptions.ConnectionString!.Ticketr))
                        .AddIdentityCore<IdentityUser>()
                        .AddRoles<IdentityRole>()
                        .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Ticketr")
                        .AddEntityFrameworkStores<TicketrDbContext>()
                        .AddDefaultTokenProviders();

                services.Configure<IdentityOptions>(options =>
                        {
                            options.Password.RequireNonAlphanumeric = dbContextOptions.Password!.RequireNonAlphanumeric;
                            options.Password.RequireDigit = dbContextOptions.Password!.RequireDigit;
                            options.Password.RequireUppercase = dbContextOptions.Password!.RequireUppercase;
                            options.Password.RequiredLength = dbContextOptions.Password!.RequiredLength;
                            options.Password.RequiredUniqueChars = dbContextOptions.Password!.RequiredUniqueChars;
                        });

                var jwtOptions = serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value;

                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = jwtOptions.Issuer,
                                ValidAudience = jwtOptions.Audience,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key!))
                            };
                        });
            });

            return instance;
        }
    }
}
