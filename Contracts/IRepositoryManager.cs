namespace Contracts;

public interface IRepositoryManager
{
	IUserRepository User { get; }
	IWalletRepository Wallet { get; }
	ITransactionRepository TransactionHistory { get; }
	ISimpleInterestRepository SimpleInterest { get; }
	Task SaveAsync();
}
