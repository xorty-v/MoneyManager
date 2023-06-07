using MoneyManager.Contracts.Categories;
using MoneyManager.Contracts.Enums;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Interfaces;
using MoneyManager.Domain.Responses;
using MoneyManager.Services.Interfaces;

namespace MoneyManager.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IBaseResponse<CategoryListViewModel>> GetCategoriesByUser(Guid userId)
    {
        try
        {
            var categories = await _categoryRepository.GetCategotiesByUser(userId);

            if (categories == null)
            {
                return new BaseResponse<CategoryListViewModel>()
                {
                    Message = "Categoties not found",
                    StatusCode = StatusCode.CategoryNotFound,
                };
            }

            var data = new CategoryListViewModel()
            {
                IncomesCategories = categories
                    .Where(c => c.Type == CategoryType.Income)
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = CategoryType.Income
                    }),
                ExpensesCategories = categories
                    .Where(c => c.Type == CategoryType.Expense)
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Type = CategoryType.Expense
                    }),
            };

            return new BaseResponse<CategoryListViewModel>()
            {
                Data = data,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryListViewModel>()
            {
                Message = $"[GetCategories] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<CategoryViewModel>> GetCategoryById(Guid id)
    {
        try
        {
            var category = await _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                return new BaseResponse<CategoryViewModel>()
                {
                    Message = "Category not found",
                    StatusCode = StatusCode.CategoryNotFound,
                };
            }
            
            var data = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Type = category.Type
            };
            
            return new BaseResponse<CategoryViewModel>()
            {
                Data = data,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<CategoryViewModel>()
            {
                Message = $"[GetCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Category>> CreateCategory(CreateCategoryViewModel model)
    {
        try
        {
            var category = await _categoryRepository.GetUserCategory(model.UserId, model.Name);

            if (category != null)
            {
                return new BaseResponse<Category>()
                {
                    Message = "This category already exists",
                    StatusCode = StatusCode.CategoryAlreadyExists
                };
            }
            
            category = new Category
            {
                Name = model.Name,
                Type = model.Type,
                UserId = model.UserId,
            };

            await _categoryRepository.Create(category);
            
            return new BaseResponse<Category>()
            {
                Message = "The category has been created",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Category>()
            {
                Message = $"[CreateCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Category>> EditCategory(CategoryViewModel model)
    {
        try
        {
            var category = await _categoryRepository.GetCategoryById(model.Id);

            if (category == null)
            {
                return new BaseResponse<Category>()
                {
                    Message = "Category not found",
                    StatusCode = StatusCode.CategoryNotFound,
                };
            }

            category.Name = model.Name;
            category.Type = model.Type;
            
            await _categoryRepository.Update(category);
            
            return new BaseResponse<Category>()
            {
                Data = category,
                Message = "Changes saved",
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<Category>()
            {
                Message = $"[EditCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteCategory(Guid id)
    {
        try
        {
            var category = await _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                return new BaseResponse<bool>()
                {
                    Message = "Category not found",
                    StatusCode = StatusCode.CategoryNotFound,
                };
            }

            await _categoryRepository.Delete(category);
            
            return new BaseResponse<bool>()
            {
                Data = true,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Message = $"[DeleteCategory] : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}