using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WalletAppApi.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
	public RepositoryContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var builder = new DbContextOptionsBuilder<RepositoryContext>()
		.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
			 b => b.MigrationsAssembly("WalletManagerApi"));
            //b => b.MigrationsAssembly("WalletAppApi"));

        return new RepositoryContext(builder.Options);
	}
}
