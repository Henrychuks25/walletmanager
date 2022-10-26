namespace Contracts;

public interface IRepositoryManager
{
	IUserRepository User { get; }
	IWalletRepository Wallet { get; }
	Task SaveAsync();
}
