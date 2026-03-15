using System.Collections.Generic;
using System.Threading.Tasks;
using Financio.Domain.Models;
using Financio.Applications.Services.Transactions.DataAccess;
using Financio.Domain.Dto;
using Financio.Domain.Mapping;

namespace Financio.Applications.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionDataAccess _dataAccess;

        public TransactionService(ITransactionDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<TransactionDto> CreateAsync(TransactionDto dtoSource)
        {
            var transaction = new Transaction
            {
                Amount = dtoSource.Amount,
                Type = (Domain.Models.TransactionType)dtoSource.Type,
                Category = dtoSource.Category,
                Description = dtoSource.Description,
                Date = dtoSource.Date
            };

            await _dataAccess.CreateAsync(transaction);

            dtoSource.TransactionId = transaction.Id;

            return dtoSource;
        } 

        public Task DeleteAsync(string id) => _dataAccess.DeleteAsync(id);

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            var getAllTransactions = await _dataAccess.GetAllAsync();

            var mapToDto = getAllTransactions.Select(x => x.MapToDto()).ToList();

            return mapToDto;

        }

        public async Task<TransactionDto> GetByIdAsync(string id)
        {
            var transaction = await _dataAccess.GetByIdAsync(id);

            var mapToDto = transaction.MapToDto();

            return mapToDto;
        }

        public async Task<TransactionDto> UpdateAsync(string id, TransactionDto transaction)
        {
            var updateTransaction = new Transaction
            {
                Id = id,
                Amount = transaction.Amount,
                Type = (Domain.Models.TransactionType)transaction.Type,
                Category = transaction.Category,
                Description = transaction.Description,
                Date = transaction.Date
            };
            await _dataAccess.UpdateAsync(id, updateTransaction);

            return updateTransaction.MapToDto();
        }
    }
}
