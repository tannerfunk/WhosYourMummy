using Microsoft.EntityFrameworkCore;
using WhosYourMummy.Models;

namespace WhosYourMummy.Data { 
    public class MummyDbContext : DbContext { 
        public MummyDbContext(DbContextOptions<MummyDbContext> options) : base(options) 
        { 
        } 

        public DbSet<Burialmain> burialmain { get; set;}
    } 
}
