namespace MoneyManager.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}