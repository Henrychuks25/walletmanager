using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<IUserRepository> _userRepository;
	private readonly Lazy<IWalletRepository> _walletRepository;
	private readonly Lazy<ITransactionRepository> _TransactionHistoryRepository;
	private readonly Lazy<ISimpleInterestRepository> _simpleInterestRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        _walletRepository = new Lazy<IWalletRepository>(() => new WalletRepository(repositoryContext));
        _TransactionHistoryRepository = new Lazy<ITransactionRepository>(() => new TransactionHistoryRepository(repositoryContext));
        _simpleInterestRepository = new Lazy<ISimpleInterestRepository>(() => new SimpleInterestRepository(repositoryContext));
	}


	public IUserRepository User => _userRepository.Value;

	public IWalletRepository Wallet => _walletRepository.Value;

	public ITransactionRepository TransactionHistory => _TransactionHistoryRepository.Value;


	public ISimpleInterestRepository SimpleInterest => _simpleInterestRepository.Value;


    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
