namespace BankAccount.Domain.Model.Entity;


public class Address
{
    public int Id { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public int? CustomerId { get; set; }
    public DateTime? DateMovedIn { get; set; } = default(DateTime?);
    public DateTime? DateMovedOut { get; set; } = default(DateTime?);

    public virtual Customer? Customer { get; set; }
}