using Auction.App.Database.Configurations;
using Auction.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Auction.App.Database;

public class DataContext : DbContext
{
    public DbSet<Member> Members { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Lot> Lots { get; set; }
    public DbSet<AuctionInfo> Auctions { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DataContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("postgres");
        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionInfoConfiguration());
        modelBuilder.ApplyConfiguration(new LotConfiguration());
    }
}
