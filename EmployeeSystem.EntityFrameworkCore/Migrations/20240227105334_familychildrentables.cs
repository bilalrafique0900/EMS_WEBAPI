using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class familychildrentables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Industry",
                table: "EmployeePreviousExperiences");

            migrationBuilder.DropColumn(
                name: "ObtainMarks",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "TotalMarks",
                table: "EmployeeEducations");

            migrationBuilder.CreateTable(
                name: "EmployeeChildrens",
                columns: table => new
                {
                    ChildrenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    NameOfChild = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChildGenderId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    ChildDateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeChildrens", x => x.ChildrenId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFamilys",
                columns: table => new
                {
                    FamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoOfDependents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfSpouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmployeeMaritalId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    MaritalStatusId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    AliveStatusId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    SpouseDateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    NameOfFather = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FatherAliveStatusId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    FatherContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameOfMother = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MotherAliveStatusId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: true),
                    MotherContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NoOfSisters = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NoOfBrothers = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFamilys", x => x.FamilyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeChildrens");

            migrationBuilder.DropTable(
                name: "EmployeeFamilys");

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "EmployeePreviousExperiences",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObtainMarks",
                table: "EmployeeEducations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalMarks",
                table: "EmployeeEducations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
