using MoneyManager.Contracts.Categories;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Responses;

namespace MoneyManager.Services.Interfaces;

public interface ICategoryService
{
    Task<IBaseResponse<CategoryListViewModel>> GetCategoriesByUser(Guid userId);
    Task<IBaseResponse<CategoryViewModel>> GetCategoryById(Guid id);
    Task<IBaseResponse<Category>> CreateCategory(CreateCategoryViewModel model);
    Task<IBaseResponse<Category>> EditCategory(CategoryViewModel model);
    Task<IBaseResponse<bool>> DeleteCategory(Guid id);
}