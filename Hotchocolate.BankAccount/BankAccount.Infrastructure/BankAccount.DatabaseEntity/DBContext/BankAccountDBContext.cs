using BankAccount.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.DatabaseEntity.DBContext;
public class BankAccountDBContext : DbContext
{

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<CustomerBankAccount> CustomerBankAccounts => Set<CustomerBankAccount>();
    public DbSet<Mortgage> Mortgages => Set<Mortgage>();
    public DbSet<LoanRelationship> LoanRelationships => Set<LoanRelationship>();
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

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{

    //   optionsBuilder.UseSqlServer("Server=AADITRIAARSHABH;Database=BankAccountProject;TrustServerCertificate=True;Integrated Security=SSPI;");
    //}


}
