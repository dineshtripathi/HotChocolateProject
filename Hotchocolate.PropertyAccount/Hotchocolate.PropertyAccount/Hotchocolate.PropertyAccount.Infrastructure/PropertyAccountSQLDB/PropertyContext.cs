using Microsoft.EntityFrameworkCore;

namespace PropertyAccountSQLDB;

public class PropertyContext : DbContext
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ContractorAndBuilder> ContractorAndBuilders { get; set; }
    public DbSet<Registration> Registrations { get; set; }

    public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Entity1
        modelBuilder.Entity<Property>(entity =>
        {
            // Configure the primary key
            entity.HasKey(e => e.Id);

            // Configure properties
            entity.Property(e => e.Rooms).IsRequired();
            entity.Property(e => e.Council).IsRequired();
            entity.Property(e => e.Rooms).IsRequired();
            entity.Property(e => e.County).IsRequired();
            entity.Property(e => e.Dateofbuilt).IsRequired();
            entity.Property(e => e.IsConstructed).IsRequired();
            entity.Property(e => e.NoOfGarages).IsRequired();
            entity.Property(e => e.NumberOfFloors).IsRequired();

            // Configure relationships
            entity.HasMany(e => e.Addresses)
                .WithOne(e => e.Property)
                .HasForeignKey(e => e.PropertyId);

            entity.HasMany(e => e.ContractorAndBuilders)
                .WithOne(e => e.Property)
                .HasForeignKey(e => e.PropertyId);
        });

        // Configure Entity2
        modelBuilder.Entity<Address>(entity =>
        {
            // Configure the primary key
            entity.HasKey(e => e.Id);

            // Configure properties
            entity.Property(e => e.AreaName).IsRequired();
            entity.Property(e => e.PropertyId).IsRequired();
            entity.Property(e => e.City).IsRequired();
            entity.Property(e => e.DateToMove).IsRequired();
            entity.Property(e => e.HouseNumber).IsRequired();
            entity.Property(e => e.IsReadyToMove).IsRequired();
            entity.Property(e => e.PostCode).IsRequired();
            entity.Property(e => e.Property).IsRequired();
            entity.Property(e => e.StreetName).IsRequired();

            // Configure relationships
            entity.HasOne(e => e.Property)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.PropertyId);

            entity.HasMany(e => e.Registrations)
                .WithOne(e => e.Address)
                .HasForeignKey(e => e.Id);
        });

        // Configure Entity3
        modelBuilder.Entity<ContractorAndBuilder>(entity =>
        {
            // Configure the primary key
            entity.HasKey(e => e.Id);

            // Configure properties
            entity.Property(e => e.PropertyId).IsRequired();
            entity.Property(e => e.AgreementNumber).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(e => e.CompanyRegistrationNumber).IsRequired();
            entity.Property(e => e.ContractorBuilderName).IsRequired();
            entity.Property(e => e.DateOfContract).IsRequired();
            entity.Property(e => e.IsSubcontractor).IsRequired();
            entity.Property(e => e.NoOfHouseAllocated).IsRequired();
            entity.Property(e => e.Id).IsRequired();

            // Configure relationships
            entity.HasOne(e => e.Property)
                .WithMany(e => e.ContractorAndBuilders)
                .HasForeignKey(e => e.PropertyId);
        });

        // Configure Entity4
        modelBuilder.Entity<Registration>(entity =>
        {
            // Configure the primary key
            entity.HasKey(e => e.Id);

            // Configure properties
            entity.Property(e => e.Address).IsRequired();
            entity.Property(e => e.DateOfRegistration).IsRequired();
            entity.Property(e => e.IsDomesticUse).IsRequired();
            entity.Property(e => e.IsFreeHold).IsRequired();
            entity.Property(e => e.NoOfRegistrant).IsRequired();
            entity.Property(e => e.NoOfYearLease).IsRequired();
            entity.Property(e => e.RegistrationNumber).IsRequired();
            entity.Property(e => e.RegistrationPlace).IsRequired();
            entity.Property(e => e.RegistterdName).IsRequired();

            // Configure relationships
            entity.HasOne(e => e.Address)
                .WithMany(e => e.Registrations)
                .HasForeignKey(e => e.AddressId);
        });
    }

}