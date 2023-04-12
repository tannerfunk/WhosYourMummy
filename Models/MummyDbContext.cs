using Microsoft.EntityFrameworkCore;

namespace WhosYourMummy.Models
{
    public class MummyDbContext : DbContext
    {
        public MummyDbContext(DbContextOptions<MummyDbContext> options) : base(options)
        {
        }

        public DbSet<Burialmain> Burialmains { get; set; }
    }
}
