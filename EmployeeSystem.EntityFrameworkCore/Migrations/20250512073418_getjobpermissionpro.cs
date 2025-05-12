using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class getjobpermissionpro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
Create PROCEDURE [dbo].[GetJobPermissions]
AS
BEGIN
    SET NOCOUNT ON;
            SELECT
    rd.RoleId,
	rl.RoleName,
    rd.DepartmentId,
	d.DepartmentName,
    COALESCE(jp.IsJobApprover, 0) AS IsJobApprover,
    COALESCE(jp.IsJobCreator, 0) AS IsJobCreator,
    COALESCE(jp.IsJobPublisher, 0) AS IsJobPublisher
FROM
    RoleDepartments rd
	Inner Join Roles rl ON rl.RoleId=rd.RoleId
	Inner Join Departments d On d.DepartmentId=rd.DepartmentId
LEFT JOIN
    JobPermissions jp
	
    ON rd.RoleId = jp.RoleId AND rd.DepartmentId = jp.DepartmentId
END ;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
