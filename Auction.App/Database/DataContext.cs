using Auction.App.Database.Configurations;
using Auction.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction.App.Database;

public class DataContext : DbContext
{
    public DbSet<Member> Members { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Lot> Lots { get; set; }
    public DbSet<AuctionInfo> Auctions { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
        modelBuilder.ApplyConfiguration(new ItemTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionInfoConfiguration());
        modelBuilder.ApplyConfiguration(new LotConfiguration());
    }
}
