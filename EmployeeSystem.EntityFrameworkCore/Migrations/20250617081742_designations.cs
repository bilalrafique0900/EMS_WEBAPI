using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class designations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Onboardings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Onboardings");
        }
    }
}
