using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAccount.DatabaseEntity.migrationscripts;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Addresses",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CustomerId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Addresses", x => x.Id);
                table.ForeignKey(
                    name: "FK_Addresses_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "CustomerBankAccounts",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CustomerId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CustomerBankAccounts", x => x.Id);
                table.ForeignKey(
                    name: "FK_CustomerBankAccounts_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "LoanRelationships",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CustomerId = table.Column<int>(type: "int", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LoanRelationships", x => x.Id);
                table.ForeignKey(
                    name: "FK_LoanRelationships_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Mortgages",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                CustomerId = table.Column<int>(type: "int", nullable: false),
                Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Term = table.Column<int>(type: "int", nullable: false),
                InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Mortgages", x => x.Id);
                table.ForeignKey(
                    name: "FK_Mortgages_Customers_CustomerId",
                    column: x => x.CustomerId,
                    principalTable: "Customers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Addresses_CustomerId",
            table: "Addresses",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_CustomerBankAccounts_CustomerId",
            table: "CustomerBankAccounts",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_LoanRelationships_CustomerId",
            table: "LoanRelationships",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_Mortgages_CustomerId",
            table: "Mortgages",
            column: "CustomerId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Addresses");

        migrationBuilder.DropTable(
            name: "CustomerBankAccounts");

        migrationBuilder.DropTable(
            name: "LoanRelationships");

        migrationBuilder.DropTable(
            name: "Mortgages");

        migrationBuilder.DropTable(
            name: "Customers");
    }
}
