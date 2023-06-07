using System.ComponentModel.DataAnnotations;
using MoneyManager.Contracts.Enums;

namespace MoneyManager.Contracts.Categories;

public class CreateCategoryViewModel
{
    public Guid UserId { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name can contain a maximum of 50 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Category type is required")]
    public CategoryType Type { get; set; }
}