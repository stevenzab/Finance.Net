namespace Financio.Applications.Services.Transactions
{
    using Financio.Domain.Dto;
    using Financio.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<TransactionDto> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<TransactionDto> CreateAsync(TransactionDto transaction, CancellationToken cancellationToken);
        Task<TransactionDto> UpdateAsync(string id, TransactionDto transaction, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
