using Microsoft.EntityFrameworkCore;
using TeledocTest.DataAccess.Configurations;
using TeledocTest.DataAccess.Entities;

namespace TeledocTest.DataAccess
{
    public class TeledocDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }

        public DbSet<FounderEntity> Founders { get; set; }
        
        public TeledocDbContext(DbContextOptions<TeledocDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FounderConfiguration());
        }
    }
}
