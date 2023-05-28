using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(75).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
    }
}