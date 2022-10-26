using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<ICompanyRepository> _companyRepository;
	private readonly Lazy<IUserRepository> _userRepository;
	private readonly Lazy<IWalletRepository> _walletRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
		_companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
        _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
        _walletRepository = new Lazy<IWalletRepository>(() => new WalletRepository(repositoryContext));
	}

	public ICompanyRepository Company => _companyRepository.Value;

	public IUserRepository User => _userRepository.Value;

	public IWalletRepository Wallet => _walletRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
