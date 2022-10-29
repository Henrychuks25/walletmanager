using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts
{
    public interface ISimpleInterestRepository
    {
        Task<double> CreateSimpleInterest(Guid userId, string currency);
        Task<Wallet> GetWalletBalance(Guid userId, string currency);

    }
}