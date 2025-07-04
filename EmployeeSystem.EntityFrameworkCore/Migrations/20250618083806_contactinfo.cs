﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class contactinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmailAddress",
                table: "Onboardings");

            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "Onboardings");

            migrationBuilder.DropColumn(
                name: "ContactPhoneNumber",
                table: "Onboardings");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Onboardings",
                newName: "ContactPersonInfo");

            migrationBuilder.AlterColumn<string>(
                name: "ClientType",
                table: "Onboardings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactPersonInfo",
                table: "Onboardings",
                newName: "Designation");

            migrationBuilder.AlterColumn<string>(
                name: "ClientType",
                table: "Onboardings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmailAddress",
                table: "Onboardings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "Onboardings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoneNumber",
                table: "Onboardings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
