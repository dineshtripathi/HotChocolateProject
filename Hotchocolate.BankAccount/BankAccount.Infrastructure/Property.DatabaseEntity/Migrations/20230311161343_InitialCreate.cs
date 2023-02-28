using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Property.DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfFloors = table.Column<int>(type: "int", nullable: false),
                    IsConstructed = table.Column<bool>(type: "bit", nullable: false),
                    Dateofbuilt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Council = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    NoOfGarages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    IsReadyToMove = table.Column<bool>(type: "bit", nullable: false),
                    DateToMove = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorAndBuilders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorBuilderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfHouseAllocated = table.Column<int>(type: "int", nullable: false),
                    IsSubcontractor = table.Column<bool>(type: "bit", nullable: false),
                    DateOfContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgreementNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyRegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorAndBuilders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorAndBuilders_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistterdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfRegistrant = table.Column<int>(type: "int", nullable: false),
                    IsDomesticUse = table.Column<bool>(type: "bit", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFreeHold = table.Column<bool>(type: "bit", nullable: false),
                    NoOfYearLease = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PropertyId",
                table: "Addresses",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorAndBuilders_PropertyId",
                table: "ContractorAndBuilders",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AddressId",
                table: "Registrations",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorAndBuilders");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
