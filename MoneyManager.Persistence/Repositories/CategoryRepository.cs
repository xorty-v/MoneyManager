using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Interfaces;

namespace MoneyManager.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Category>> GetCategotiesByUser(Guid userId)
    {
        return await _dbContext.Categories.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<Category> GetCategoryById(Guid categoryId)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<Category> GetUserCategory(Guid userId, string nameCategory)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(c => c.UserId == userId && c.Name == nameCategory);
    }

    public async Task Create(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Category category)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Category category)
    {
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }
}