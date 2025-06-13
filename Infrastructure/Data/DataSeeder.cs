using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var fixedDate = new DateTime(2024, 6, 13, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("C21FEB91-5CBB-4F8A-884A-0597444E7BB2"),
                    Username = "Brokey",
                    Balance = 0,
                    CreatedAt = fixedDate
                },
                new User()
                {
                    Id = new Guid("B175F222-DE5D-473C-AF2C-59A713BF4C95"),
                    Username = "Rich",
                    Balance = 500000,
                    CreatedAt = fixedDate
                },
                new User()
                {
                    Id = new Guid("4585CE1A-5A9D-4AF8-9829-92490BB9F2A3"),
                    Username = "John",
                    Balance = 10000,
                    CreatedAt = fixedDate
                },
                new User()
                {
                    Id = new Guid("A0C167F1-3D60-4E8D-8B46-114DB223284F"),
                    Username = "Jane",
                    Balance = 256698,
                    CreatedAt = fixedDate
                },
                new User()
                {
                    Id = new Guid("D39375A6-43F7-4BEE-AE3F-745CCDE7EAC4"),
                    Username = "Sam",
                    Balance = 25605.5m,
                    CreatedAt = fixedDate
                }
            );
        }
    }
}
