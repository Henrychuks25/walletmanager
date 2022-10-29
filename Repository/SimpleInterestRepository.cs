using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using Shared.Helpers;
using static Shared.DataTransferObjects.WalletUserTransferDto;

namespace Repository;

internal sealed class SimpleInterestRepository : RepositoryBase<Wallet>, ISimpleInterestRepository
{
	public SimpleInterestRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async  Task<double> CreateSimpleInterest(Guid userId, string currency)
	{
        WalletUserTopUpDto walletUser;
        var interest = 0.00;
        // interest is prt/100
        int noOfDays = DateTime.Now.Subtract(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).Days + 1;
        CurrentTime currentTime = new CurrentTime();
        string time = currentTime.getCurrentTime();
        //string time = "12:00:00 PM";
        double interestRate = 0.1;
        var result = await GetWalletBalance(userId, currency);
        if(result != null && result.Currency.Contains("NGN") && time.Equals("12:00:00 AM"))
        {
            double principal = (double)result.Amount;
            
             interest = (principal * interestRate * noOfDays) / 100;
            result.Amount += (decimal) interest;
            result.UpdatedDate = DateTime.Now;

            await RepositoryContext.SaveChangesAsync();

        }
        else if(result != null && result.Currency.Contains("USD") && time.Equals("12:00:00 AM"))
        {
            double principal = (double)result.Amount;

             interest =  (principal * interestRate * noOfDays) / 100;
            result.Amount += (decimal)interest;
            result.UpdatedDate = DateTime.Now;
            await RepositoryContext.SaveChangesAsync();

        }
        else
        {
            interest = 0.00;
        }

        return interest;
    }

    public async Task<Wallet> GetWalletBalance(Guid userId, string currency)
    {
        var result = await RepositoryContext.Wallets
            .Where(u => u.Id == userId && u.Currency.Equals(currency) ).FirstOrDefaultAsync();


        return result;

    }

  
}
