using Microsoft.EntityFrameworkCore;
using TeledocTest.DataAccess.Entities;

namespace TeledocTest.DataAccess
{
    public class TeledocDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<FounderEntity> Founders { get; set; }
        
        public TeledocDbContext(DbContextOptions<TeledocDbContext> options) : base(options) { }
    }
}
