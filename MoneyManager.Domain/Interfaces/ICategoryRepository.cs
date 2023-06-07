using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategotiesByUser(Guid userId);
    Task<Category> GetCategoryById(Guid сategoryId);
    Task<Category> GetUserCategory(Guid userId, string nameCategory);
    Task Create(Category category);
    Task Update(Category category);
    Task Delete(Category category);
}