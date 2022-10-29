using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts
{
    public interface ITransactionRepository
    {

        Task<IEnumerable<TransactionHistoryDto>> GetTransactionsAsync(Guid userId);
        Task<TransactionHistoryDto> GetTransactionAsync(Guid userId);
        Task<IEnumerable<TransactionHistory>> GetAllTransactionsAsync(bool trackChanges);

        Task CreateUserTransaction(TransactionHistory transaction);
        Task CreateTransaction(Guid userId);


    }
}