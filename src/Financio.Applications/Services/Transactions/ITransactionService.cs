namespace Financio.Applications.Services.Transactions
{
    using Financio.Domain.Dto;
    using Financio.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<TransactionDto> GetByIdAsync(string id);
        Task<TransactionDto> CreateAsync(TransactionDto transaction);
        Task<TransactionDto> UpdateAsync(string id, TransactionDto transaction);
        Task DeleteAsync(string id);
    }
}
