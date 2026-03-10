using Financio.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financio.Applications.Services.Transactions.DataAccess
{
    public interface ITransactionDataAccess
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction> GetByIdAsync(string id);
        Task CreateAsync(Transaction transaction);
        Task UpdateAsync(string id, Transaction transaction);
        Task DeleteAsync(string id);
    }
}
