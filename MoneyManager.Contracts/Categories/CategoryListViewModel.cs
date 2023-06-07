namespace MoneyManager.Contracts.Categories;

public class CategoryListViewModel
{
    public IEnumerable<CategoryViewModel> IncomesCategories  { get; set; }
    public IEnumerable<CategoryViewModel> ExpensesCategories { get; set; }
}