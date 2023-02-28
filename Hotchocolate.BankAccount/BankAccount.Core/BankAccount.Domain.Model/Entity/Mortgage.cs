namespace BankAccount.Domain.Model.Entity;

public class Mortgage
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public decimal Amount { get; set; }

    public int Term { get; set; }

    public decimal InterestRate { get; set; }
    public decimal CommissionCharge { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public DateTime MortageStartDate { get; set; }
    public DateTime MortageMonthlyDate { get; set; }
    public DateTime MortageEndDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}