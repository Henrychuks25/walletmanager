using Entities.Models;
using Shared.DataTransferObjects;

namespace Contracts;

public interface IUserRepository
{
	Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
	Task<User> GetUserAsync(Guid userId, bool trackChanges);
	Task<User> GetUserEmailAsync(string email, bool trackChanges);
	Task<User> GetUserEmailPasswordAsync(string email, string password, bool trackChanges);
	void Create(User user);

	Task <User> GetUserWallet(Guid id, bool trackChanges);
    Task<User> Get(Guid userId);
    Task<User> GetWallet(WalletUserTopUpDto walletUser);

    void Delete(User user);

}
