using Domain.Contracts.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var userFromDB = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userFromDB != null)
            {
                foreach (var property in typeof(User).GetProperties())
                {
                    if (property.Name != "Id" && property != null)
                    {
                        var newValue = property.GetValue(user);

                        property.SetValue(userFromDB, newValue);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            _context.Users.Update(userFromDB);
            return userFromDB;
        }
    }
}