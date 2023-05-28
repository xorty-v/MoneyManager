using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByEmail(Guid userId);
    Task Create(User user);
}