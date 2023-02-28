namespace BankAccount.Domain.Model.Entity;

public class LoanRelationship
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public decimal Amount { get; set; }

    public decimal InterestRate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}