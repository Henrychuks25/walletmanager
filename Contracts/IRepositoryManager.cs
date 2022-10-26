namespace Contracts;

public interface IRepositoryManager
{
	ICompanyRepository Company { get; }
	IUserRepository User { get; }
	IWalletRepository Wallet { get; }
	Task SaveAsync();
}
