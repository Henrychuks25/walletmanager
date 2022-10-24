using Entities.Models;

namespace Contracts;

public interface IUserRepository
{
	Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
	Task<User> GetUserAsync(Guid userId, bool trackChanges);
	Task<User> GetUserEmailAsync(string email, bool trackChanges);
	Task<User> GetUserEmailPasswordAsync(string email, string password, bool trackChanges);
	void Create(User user);
	void Delete(User user);
}
