using BankAccount.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankAccount.DatabaseEntity.DBContext;
public partial class BankAccountDBContext : DbContext
{

    public virtual DbSet<Customer> Customers {get;set;}
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<CustomerBankAccount> CustomerBankAccounts { get; set; }
    public virtual DbSet<Mortgage> Mortgages { get; set; }
    public virtual DbSet<LoanRelationship> LoanRelationships { get; set; }
    //public BankAccountDBContext()
    //{

    //}
    public BankAccountDBContext(DbContextOptions<BankAccountDBContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Addresses_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Addresses).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<CustomerBankAccount>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_CustomerBankAccounts_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerBankAccounts).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<LoanRelationship>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_LoanRelationships_CustomerId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.LoanRelationships).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Mortgage>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Mortgages_CustomerId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Mortgages).HasForeignKey(d => d.CustomerId);
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
   
    
}

