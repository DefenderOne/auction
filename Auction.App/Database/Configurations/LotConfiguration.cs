using Auction.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.App.Database.Configurations;

public class LotConfiguration : IEntityTypeConfiguration<Lot>
{
    public void Configure(EntityTypeBuilder<Lot> builder)
    {
        builder.HasKey(l => new { l.Id, l.AuctionId });
        builder.HasIndex(l => l.ItemId).IsUnique();
        builder.HasOne(l => l.Item).WithOne(i => i.Lot).HasForeignKey<Lot>(l => l.ItemId);
        builder.HasOne(l => l.Auction).WithMany(a => a.Lots).HasForeignKey(l => l.AuctionId);
        builder.HasOne(l => l.Buyer).WithMany(a => a.BoughtItems).HasForeignKey(i => i.BuyerId);
        builder.Property(l => l.StartPrice).IsRequired();
    }
}
