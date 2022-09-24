using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
	

	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("secrets.json", optional: true)
				.AddJsonFile("appsettings.json", optional: true)
				.AddJsonFile($"appsettings.{envName}.json", optional: true)
				.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
				.Build();

			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			;
			builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName()
				.Name));

			return new ApplicationDbContext(builder.Options);


		}


	}
}