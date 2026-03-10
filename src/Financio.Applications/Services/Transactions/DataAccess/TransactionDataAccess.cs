using Financio.Domain.Models;
using Financio.Infrastructure.Common;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financio.Applications.Services.Transactions.DataAccess
{
    public class TransactionDataAccess : ITransactionDataAccess
    {
        private readonly IBaseRepository _baseRepository;

        public TransactionDataAccess(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task CreateAsync(Transaction transaction)
        {
            await _baseRepository.AddAsync(transaction);
        }

        public async Task DeleteAsync(string id)
        {
            var collection = _baseRepository.GetCollection<Transaction>("Transaction");
            await collection.DeleteOneAsync(t => t.Id == id);
        }

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
            var items = _baseRepository.AsQueryable<Transaction>().OrderByDescending(t => t.Date).ToList();
            return Task.FromResult<IEnumerable<Transaction>>(items);
        }

        public Task<Transaction> GetByIdAsync(string id)
        {
            var item = _baseRepository.AsQueryable<Transaction>().FirstOrDefault(t => t.Id == id);
            return Task.FromResult(item);
        }

        public async Task UpdateAsync(string id, Transaction transaction)
        {
            var collection = _baseRepository.GetCollection<Transaction>("Transaction");
            transaction.Id = id;
            transaction.Updated = System.DateTime.Now;
            await collection.ReplaceOneAsync(t => t.Id == id, transaction, new ReplaceOptions { IsUpsert = false });
        }
    }
}
