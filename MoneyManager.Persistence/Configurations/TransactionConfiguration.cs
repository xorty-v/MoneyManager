using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(250);
        builder.Property(x => x.DateCreated).IsRequired();
    }
}