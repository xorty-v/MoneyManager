using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities;
using MoneyManager.Persistence.Configurations;

namespace MoneyManager.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) => Database.Migrate();

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new TransactionConfiguration());
        
        base.OnModelCreating(builder);
    }
}