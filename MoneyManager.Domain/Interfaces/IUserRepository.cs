using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByEmail(string email);
    Task Create(User user);
}