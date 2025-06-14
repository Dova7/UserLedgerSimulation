using Domain.Contracts.Behaviors;
using Domain.Entities;

namespace Domain.Contracts.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>, IFullyUpdateable<User>, ISaveable
    {

    }
}
