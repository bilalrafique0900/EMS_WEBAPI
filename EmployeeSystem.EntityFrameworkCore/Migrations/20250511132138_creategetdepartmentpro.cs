using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class creategetdepartmentpro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
Create PROCEDURE [dbo].[GetRoleDepartments]
@pageSize int = 10,
@pageNo    int = 1,
@seaechText nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON;
            SELECT rl.RoleId,rl.RoleName,
			COUNT(*) OVER() AS TotalRecords
			FROM RoleDepartments rd
			INNER join Roles rl ON rl.RoleId = rd.RoleId
			INNER join Departments d ON d.DepartmentId = rd.DepartmentId
			WHERE (@seaechText = '' OR d.DepartmentName Like  '%'+@seaechText+'%') OR (@seaechText = '' OR rl.RoleName Like  '%'+@seaechText+'%')
  ORDER BY DAY(rl.RoleName) DESC
  OFFSET ((@pageNo - 1) * @pageSize) ROWS
  FETCH NEXT @pageSize ROWS ONLY
END ;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
