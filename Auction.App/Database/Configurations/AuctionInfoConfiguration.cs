using Auction.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.App.Database.Configurations;

public class AuctionInfoConfiguration : IEntityTypeConfiguration<AuctionInfo>
{
    public void Configure(EntityTypeBuilder<AuctionInfo> builder)
    {
        builder.HasKey(ai => ai.Id);
        builder.Property(ai => ai.Date).IsRequired();
    }
}
