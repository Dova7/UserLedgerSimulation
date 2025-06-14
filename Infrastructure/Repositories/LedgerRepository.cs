using Domain.Contracts.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LedgerRepository : BaseRepository<Ledger>, ILedgerRepository
    {
        private readonly ApplicationDbContext _context;

        public LedgerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Ledger> UpdateAsync(Ledger ledger)
        {
            if (ledger == null)
            {
                throw new ArgumentNullException(nameof(ledger));
            }
            var ledgerFromDB = await _context.Ledgers.FirstOrDefaultAsync(l => l.Id == ledger.Id);
            if (ledgerFromDB != null)
            {
                foreach (var property in typeof(Ledger).GetProperties())
                {
                    if (property.Name != "Id" && property != null)
                    {
                        var newValue = property.GetValue(ledger);

                        property.SetValue(ledgerFromDB, newValue);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            _context.Ledgers.Update(ledgerFromDB);
            return ledgerFromDB;
        }
    }
}
