using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class getdepartmentprocedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
Create PROCEDURE [dbo].[GetDepartments]
@pageSize int = 10,
@pageNo    int = 1,
@seaechText nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON;
  SELECT
   d.DepartmentId,
   d.DepartmentName,
   d.GroupId,
   d.IsActive,
   d.IsDeleted,
   d.UpdatedBy,
   d.UpdatedDate,
   d.CreatedBy,
   d.CreatedDate,
   g.GroupName
   ,COUNT(*) OVER () AS TotalRecords
  
  FROM  Departments d
    Inner Join Groups g on d.GroupId=g.GroupId

 WHERE (@seaechText = '' OR  LOWER(d.DepartmentName) Like  '%'+LOWER(@seaechText) +'%')
  AND d.IsDeleted != 1
  ORDER BY d.CreatedDate DESC
  OFFSET ((@pageNo-1) * @pageSize) ROWS
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
