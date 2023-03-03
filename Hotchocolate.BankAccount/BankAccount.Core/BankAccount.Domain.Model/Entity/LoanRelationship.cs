namespace BankAccount.Domain.Model.Entity;

public class LoanRelationship
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public decimal Amount { get; set; }

    public decimal InterestRate { get; set; }


    public decimal Balance { get; set; } = 0;
    public decimal TotalAmount { get; set; }
    public decimal TotalFee { get; set; }
    public string Currency { get; set; }
    public DateTime LoanStartDate { get; set; }
    public int IsLoan { get; set; }
    public DateTime LoanEndDate { get;set; }
    public DateTime LoanApprovedDate { get; set; }
    public virtual Customer Customer { get; set; } = null!;
}