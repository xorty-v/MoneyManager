using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetTransactionsByUser(Guid userId);
    Task Create(Transaction transaction);
    Task Update(Transaction transaction);
}