using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Interfaces;

namespace MoneyManager.Persistence.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TransactionRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<IEnumerable<Transaction>> GetTransactionsByUser(Guid userId)
    {
        return await _dbContext.Transactions.Where(t => t.Category.UserId == userId).ToListAsync();
    }

    public async Task Create(Transaction transaction)
    {
        await _dbContext.Transactions.AddAsync(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Transaction transaction)
    {
        _dbContext.Transactions.Update(transaction);
        await _dbContext.SaveChangesAsync();
    }
}