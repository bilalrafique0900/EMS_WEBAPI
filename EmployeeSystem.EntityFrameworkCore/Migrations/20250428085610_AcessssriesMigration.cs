using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AcessssriesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    AccessoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessoriesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessBrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.AccessoriesId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAccessories",
                columns: table => new
                {
                    EmployeeAccessoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAccessories", x => x.EmployeeAccessoriesId);
                    table.ForeignKey(
                        name: "FK_EmployeeAccessories_Accessories_AccessoriesId",
                        column: x => x.AccessoriesId,
                        principalTable: "Accessories",
                        principalColumn: "AccessoriesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAccessories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccessories_AccessoriesId",
                table: "EmployeeAccessories",
                column: "AccessoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccessories_EmployeeId",
                table: "EmployeeAccessories",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAccessories");

            migrationBuilder.DropTable(
                name: "Accessories");
        }
    }
}
