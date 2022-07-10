using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Auction.App.Database;

public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("postgres");
        var contextOptions = new DbContextOptionsBuilder()
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()
            .Options;
        return new DataContext(contextOptions);
    }
}
