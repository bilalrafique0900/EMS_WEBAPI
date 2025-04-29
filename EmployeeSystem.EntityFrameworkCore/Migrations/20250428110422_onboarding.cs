using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class onboarding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Onboardings",
                columns: table => new
                {
                    OnboardingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactEmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumberOfEmployees = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ServicesRequired = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OnboardingStartDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    SpecialRequirementOrNotes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onboardings", x => x.OnboardingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Onboardings");
        }
    }
}
