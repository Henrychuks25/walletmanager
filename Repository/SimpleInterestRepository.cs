using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using static Shared.DataTransferObjects.WalletUserTransferDto;

namespace Repository;

internal sealed class SimpleInterestRepository : RepositoryBase<Wallet>, ISimpleInterestRepository
{
	public SimpleInterestRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async Task<IEnumerable<Wallet>> GetAllWalletAsync(bool trackChanges) =>
		await FindAll(trackChanges)
		.OrderBy(c => c.Currency)
		.ToListAsync();

	public async Task<Wallet> GetAsync(Guid walletId, bool trackChanges) =>
		await FindByCondition(c => c.Id.Equals(walletId), trackChanges)
		.SingleOrDefaultAsync();

	





	public async Task<User> GetUserWallet( Guid id, bool trackChanges) => await RepositoryContext.User.Include(c => c.Wallets).FirstOrDefaultAsync(u => u.Id == id);


	public async Task CreateWallet(Guid userId, string currency) => await RepositoryContext.Wallets.AddAsync(new Wallet() { UserId = userId, Currency = currency, CreatedDate = DateTime.Now });

	public async Task TopUp(WalletUserTopUpDto walletUser)
	{
        var wallet = await GetWalletAsync(walletUser.userId, walletUser.currency);
        if (wallet is null)
            return;

        wallet.Amount += walletUser.amount;
		wallet.UpdatedDate = DateTime.Now;

        await RepositoryContext.SaveChangesAsync();
    }

	public async Task Withdraw(WalletUserWithdrawDto walletUser)
	{
        var wallet = await GetWalletAsync(walletUser.userId, walletUser.currency);
        if (wallet is null)
            return;

        if (walletUser.amount > wallet.Amount)
            throw new Exception("Not Enough funds");

        wallet.Amount -= walletUser.amount;

        await RepositoryContext.SaveChangesAsync();
    }
    public async Task<User> Get(Guid userId) => await RepositoryContext.User.Include(c => c.Wallets).FirstOrDefaultAsync(u => u.Id == userId);
    //public async Task<IEnumerable<User>> GetWalletsBalance(Guid userId) => await RepositoryContext.User.Include(c => c.Wallets).Where(u => u.Id == userId).ToListAsync();
    public async Task<IEnumerable<User>> GetWalletsBalance(Guid userId)
	{
        var  result =   await RepositoryContext.User.Include(c => c.Wallets)
			.Where(u => u.Id == userId).ToListAsync();
        

		return result;

    } 



	public async Task<Wallet> GetWalletAsync(Guid userId, string currency) => await RepositoryContext.Wallets.FirstOrDefaultAsync(u => u.UserId == userId && u.Currency == currency);

	public async Task<IEnumerable<Wallet>> GetAllWalletByUserIdAsync(Guid userId)
	{
	return	await RepositoryContext.Wallets.Where(u => u.UserId == userId).ToListAsync();
    }
}
