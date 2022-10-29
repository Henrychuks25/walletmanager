using Entities.Models;
using Shared.DataTransferObjects;
using static Shared.DataTransferObjects.WalletUserTransferDto;

namespace Contracts;

public interface IWalletRepository
{
	Task<IEnumerable<Wallet>> GetAllWalletAsync(bool trackChanges);
	Task<IEnumerable<Wallet>> GetAllWalletByUserIdAsync(Guid userId);
	Task<Wallet> GetAsync(Guid walletId, bool trackChanges);
	Task<Wallet> GetWalletAsync(Guid walletId, string currency);
    Task CreateWallet(Guid userId, string currency);
    Task<User> Get(Guid userId);
    Task<IEnumerable<User>> GetWalletsBalance(Guid userId);
    //Task<IEnumerable<User>> GetWalletsBalance(Guid userId);
    Task TopUp(WalletUserTopUpDto walletUser);
    Task Withdraw(WalletUserWithdrawDto walletUser);
    //Task Transfer(WalletUserTransferDto walletUser);
}
