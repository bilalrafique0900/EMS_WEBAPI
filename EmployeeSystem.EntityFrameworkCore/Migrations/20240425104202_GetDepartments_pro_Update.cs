using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class GetDepartments_pro_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
ALTER PROCEDURE [dbo].[GetDepartments]
@pageSize int = 10,
@pageNo int = 1,
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
        g.GroupName,
        COUNT(*) OVER () AS TotalRecords
    FROM
        Departments d
    INNER JOIN
        Groups g ON d.GroupId = g.GroupId
    WHERE
        (@seaechText = '' OR LOWER(d.DepartmentName) LIKE '%'+LOWER(@seaechText) +'%'
        OR g.GroupName = @seaechText)
        AND d.IsDeleted != 1
		    ORDER BY
        g.GroupName
    OFFSET ((@pageNo - 1) * @pageSize) ROWS
    FETCH NEXT @pageSize ROWS ONLY
END;


");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
