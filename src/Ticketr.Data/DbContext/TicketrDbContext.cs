using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ticketr.Data.DbContext
{
    public class TicketrDbContext : IdentityDbContext
    {
        public TicketrDbContext(DbContextOptions<TicketrDbContext> options) : base(options)
        {
        }
    }
}
