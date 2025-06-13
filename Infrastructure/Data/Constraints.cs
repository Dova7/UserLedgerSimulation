using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class Constraints
    {
        public static void UserConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.Username).IsRequired();
                e.Property(x => x.CreatedAt).IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.Balance).IsRequired();
            });
            modelBuilder.Entity<User>()
                .HasMany(x => x.Ledgers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void LedgerConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ledger>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.TimeStamp).IsRequired().ValueGeneratedOnAdd();
                e.Property(x => x.Amount).IsRequired();
            });
            modelBuilder.Entity<Ledger>()
                .HasOne(x => x.User)
                .WithMany(x => x.Ledgers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
