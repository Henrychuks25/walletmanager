using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
	public RepositoryContext(DbContextOptions options)
		: base(options)
	{
	}

	public RepositoryContext()
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		
	}


	public DbSet<User>? User { get; set; }
	public DbSet<TransactionHistory>? TransactionHistories { get; set; }
	public DbSet<Wallet>? Wallets { get; set; }
}
