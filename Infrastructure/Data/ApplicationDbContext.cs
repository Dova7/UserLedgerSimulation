using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UserConstraints();
            modelBuilder.LedgerConstraints();
            modelBuilder.SeedUsers();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
    }
}
