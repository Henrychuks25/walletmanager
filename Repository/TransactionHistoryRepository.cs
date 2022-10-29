using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System.Transactions;
using static Shared.DataTransferObjects.WalletUserTransferDto;

namespace Repository;

internal sealed class TransactionHistoryRepository : RepositoryBase<TransactionHistory>, ITransactionRepository
{
	public TransactionHistoryRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	








	
	public async Task<IEnumerable<TransactionHistoryDto>> GetTransactionsAsync(Guid userId)
	{
		var transHistory = new List<TransactionHistoryDto>();
	 var result =	await RepositoryContext.TransactionHistories.FirstOrDefaultAsync(u => u.UserId == userId);
		if(result != null)
		{

			foreach(var item in transHistory)
			{
				item.UpdatedDate = result.UpdatedDate;
				item.CreatedDate = result.CreatedDate;
				item.UserId = result.UserId;
				item.TransactionAmount = result.TransactionAmount;
				item.TransactionType = result.TransactionType;

			}
		}
		return transHistory;
	}

	

	public async Task<IEnumerable<TransactionHistory>> GetAllTransactionsAsync(bool trackChanges)
	{
		var result = await FindAll(trackChanges)
        .OrderBy(c => c.TransactionType)
        .ToListAsync();

		return (IEnumerable<TransactionHistory>)result;
    }
       

	public async Task CreateUserTransaction(TransactionHistory transaction)
	{
		await RepositoryContext.TransactionHistories.AddAsync(transaction);
        await RepositoryContext.SaveChangesAsync();



    }
    //=>  Create(transaction);

    public async Task CreateTransaction(Guid userId) 
		=> await RepositoryContext.TransactionHistories.AddAsync(new TransactionHistory() {
			UserId = userId
		
		});

	public async Task<TransactionHistoryDto> GetTransactionAsync(Guid userId)
	{
		var result = new TransactionHistoryDto();
       var transHistory =  await RepositoryContext.TransactionHistories.FirstOrDefaultAsync(u => u.UserId == userId);
		var getUser = await RepositoryContext.User.FirstOrDefaultAsync(u => u.Id == userId);
		if(transHistory != null)
		{
			result.UpdatedDate = transHistory.UpdatedDate;
			result.CreatedDate = transHistory.CreatedDate;
			result.TransactionAmount = transHistory.TransactionAmount;
			result.TransactionType = transHistory.TransactionType;

			result.username = $"{getUser.FirstName} {getUser.LastName}";	
		}

        
		return result;
    }

	


	//public async Task<User> GetUserWallet(Guid id, bool trackChanges) => await RepositoryContext.User.Include(c => c.Wallets).FirstOrDefaultAsync(u => u.Id == id);

}
