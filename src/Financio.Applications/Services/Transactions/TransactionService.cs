using System.Collections.Generic;
using System.Threading.Tasks;
using Financio.Domain.Models;
using Financio.Applications.Services.Transactions.DataAccess;

namespace Financio.Applications.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionDataAccess _dataAccess;

        public TransactionService(ITransactionDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task CreateAsync(Transaction transaction) => _dataAccess.CreateAsync(transaction);

        public Task DeleteAsync(string id) => _dataAccess.DeleteAsync(id);

        public Task<IEnumerable<Transaction>> GetAllAsync() => _dataAccess.GetAllAsync();

        public Task<Transaction> GetByIdAsync(string id) => _dataAccess.GetByIdAsync(id);

        public Task UpdateAsync(string id, Transaction transaction) => _dataAccess.UpdateAsync(id, transaction);
    }
}
