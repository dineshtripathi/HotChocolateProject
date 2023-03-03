namespace BankAccount.Domain.Model.Entity;

public class Customer
{

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime ApprovedDate { get; set; }

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();

    public virtual ICollection<CustomerBankAccount> CustomerBankAccounts { get; } = new List<CustomerBankAccount>();

    public virtual ICollection<LoanRelationship> LoanRelationships { get; } = new List<LoanRelationship>();

    public virtual ICollection<Mortgage> Mortgages { get; } = new List<Mortgage>();
}

/*
 
public class Customer
{
    private ICollection<Address>? _address;
    private ICollection<CustomerBankAccount>? _customerBankAccounts;
    private ICollection<LoanRelationship>? _loanRelationships;
    private ICollection<Mortgage>? _mortgages;

    private ILazyLoader LazyLoader { get; set; }


    public Customer(ILazyLoader lazyLoader)
    {
        LazyLoader = lazyLoader;
    }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Address>? Addresses
    {
        get => LazyLoader.Load(this, ref _address);
        set => _address = value;
    }

    public virtual ICollection<CustomerBankAccount>? CustomerBankAccounts
    {
        get => LazyLoader.Load(this, ref _customerBankAccounts);
        set => _customerBankAccounts = value;
    }

    public virtual ICollection<LoanRelationship>? LoanRelationships
    {
        get => LazyLoader.Load(this, ref _loanRelationships);
        set => _loanRelationships = value;
    }

    public virtual ICollection<Mortgage>? Mortgages
    {
        get => LazyLoader.Load(this, ref _mortgages);
        set => _mortgages = value;
    }
}
 */ 