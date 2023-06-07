using MoneyManager.Contracts.Enums;

namespace MoneyManager.Contracts.Categories;

public class CategoryViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CategoryType Type { get; set; }
}