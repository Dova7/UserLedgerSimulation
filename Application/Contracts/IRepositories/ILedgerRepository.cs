using Domain.Contracts.Behaviors;
using Domain.Entities;

namespace Domain.Contracts.IRepositories
{
    public interface ILedgerRepository : IBaseRepository<Ledger>, IFullyUpdateable<Ledger>, ISaveable
    {
            
    }
}
