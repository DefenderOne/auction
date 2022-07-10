using Auction.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.App.Database.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Name).IsRequired();
        builder.HasIndex(i => i.Name).IsUnique();
        builder.HasOne(i => i.Type).WithMany(i => i.Items).HasForeignKey(i => i.TypeId);
        builder.HasOne(i => i.Owner).WithMany(i => i.Items).HasForeignKey(i => i.OwnerId);
        builder.Property(i => i.ReceivedAt).IsRequired();
        builder.Property(i => i.IsSold).HasDefaultValue(false);
    }
}
