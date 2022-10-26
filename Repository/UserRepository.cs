using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;

namespace Repository;

internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
{
	public UserRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
		await FindAll(trackChanges)
		.OrderBy(c => c.FirstName)
		.ToListAsync();

	public async Task<User> GetUserAsync(Guid userId, bool trackChanges) =>
		await FindByCondition(c => c.Id.Equals(userId), trackChanges)
		.SingleOrDefaultAsync();

	public void CreateUser(User user) => Create(user);
	public void DeleteUser(User user) => Create(user);




	public async Task<User> GetUserEmailAsync(string email, bool trackChanges) =>
		await FindByCondition(c => c.Email.Equals(email), trackChanges)
		.SingleOrDefaultAsync();
	public async Task<User> GetUserEmailPasswordAsync(string email, string password, bool trackChanges) =>
		 await FindByCondition(c => c.Email.Equals(email) && c.Password.Equals(password), trackChanges)
		 .SingleOrDefaultAsync();

	public async Task<User> GetUserWallet(Guid id, bool trackChanges) => await RepositoryContext.User.Include(c => c.Wallets).FirstOrDefaultAsync(u => u.Id == id);
    public async Task<User> GetWallet(WalletUserTopUpDto walletUser) => await RepositoryContext.User.Include(c => c.Wallets).FirstOrDefaultAsync(u => u.Id == walletUser.userId);

    public async Task<User> Get(Guid userId) => await RepositoryContext.User.Include(c => c.Wallets).FirstOrDefaultAsync(u => u.Id == userId);

}