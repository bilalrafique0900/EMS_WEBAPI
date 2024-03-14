using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class dbtableschanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AliveStatusId",
                table: "EmployeeFamilys");

            migrationBuilder.RenameColumn(
                name: "EmployeeMaritalId",
                table: "EmployeeFamilys",
                newName: "SpouseAliveStatusId");

            migrationBuilder.RenameColumn(
                name: "NameOfDegree",
                table: "EmployeeEducations",
                newName: "NameOfHighestDegree");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpouseAliveStatusId",
                table: "EmployeeFamilys",
                newName: "EmployeeMaritalId");

            migrationBuilder.RenameColumn(
                name: "NameOfHighestDegree",
                table: "EmployeeEducations",
                newName: "NameOfDegree");

            migrationBuilder.AddColumn<Guid>(
                name: "AliveStatusId",
                table: "EmployeeFamilys",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: true);
        }
    }
}
