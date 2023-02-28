namespace BankAccount.Domain.Model.Entity;
public class CustomerBankAccount
{
    public int Id { get; set; }

    public string? AccountNumber { get; set; }

    public string? BankName { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}

