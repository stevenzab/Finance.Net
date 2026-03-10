namespace Financio.Applications.Services.Transactions
{
    using Financio.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction> GetByIdAsync(string id);
        Task CreateAsync(Transaction transaction);
        Task UpdateAsync(string id, Transaction transaction);
        Task DeleteAsync(string id);
    }
}
