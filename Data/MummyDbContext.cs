using Microsoft.EntityFrameworkCore;
namespace WhosYourMummy.Data { 
    public class MummyDbContext : DbContext { 
        public MummyDbContext(DbContextOptions<MummyDbContext> options) : base(options) 
        { 
        } 
    } 
}
