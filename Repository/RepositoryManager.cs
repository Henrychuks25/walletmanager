using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<IUserRepository> _userRepository;
	private readonly Lazy<IWalletRepository> _walletRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        _walletRepository = new Lazy<IWalletRepository>(() => new WalletRepository(repositoryContext));
	}


	public IUserRepository User => _userRepository.Value;

	public IWalletRepository Wallet => _walletRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
