using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

	public void Create(User user) => Create(user);
	public void Delete(User user) => Create(user);




    public async Task<User> GetUserEmailAsync(string email, bool trackChanges) =>
        await FindByCondition(c => c.Email.Equals(email), trackChanges)
        .SingleOrDefaultAsync();
    public async Task<User> GetUserEmailPasswordAsync(string email, string password, bool trackChanges) =>
         await FindByCondition(c => c.Email.Equals(email) && c.PasswordHash.Equals(password), trackChanges)
         .SingleOrDefaultAsync();


	

}
