using Auction.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction.App.Database.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name).IsRequired();
        builder.Property(m => m.PhoneNumber).IsRequired();
    }
}
