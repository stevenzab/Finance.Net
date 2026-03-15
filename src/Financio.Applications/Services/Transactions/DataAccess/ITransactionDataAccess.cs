using Financio.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financio.Applications.Services.Transactions.DataAccess
{
    public interface ITransactionDataAccess
    {
        Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken);
        Task<Transaction> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task CreateAsync(Transaction transaction);
        Task UpdateAsync(string id, Transaction transaction);
        Task DeleteAsync(string id);
    }
}
