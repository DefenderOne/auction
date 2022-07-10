using Auction.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.App.Database.Configurations;

public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
{
    public void Configure(EntityTypeBuilder<ItemType> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.Name).IsRequired();
        builder.HasIndex(it => it.Name).IsUnique();
    }
}
