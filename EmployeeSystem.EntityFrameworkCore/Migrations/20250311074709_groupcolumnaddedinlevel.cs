using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class groupcolumnaddedinlevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExecutive",
                table: "Levels");

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Levels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Levels");

            migrationBuilder.AddColumn<bool>(
                name: "IsExecutive",
                table: "Levels",
                type: "bit",
                nullable: true);
        }
    }
}
