using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class createjobPermission1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPermissions",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsJobCreator = table.Column<bool>(type: "bit", nullable: true),
                    IsJobApprover = table.Column<bool>(type: "bit", nullable: true),
                    IsJobPublisher = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPermissions");
        }
    }
}
