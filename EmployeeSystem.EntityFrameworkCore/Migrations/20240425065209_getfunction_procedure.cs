using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class getfunction_procedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
Create PROCEDURE [dbo].[GetFunctions]
@pageSize int = 10,
@pageNo    int = 1,
@seaechText nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON;
  SELECT
   f.FunctionId,
   f.FunctionName,
   f.GroupId,
   g.GroupName,
   f.IsActive,
   f.IsDeleted,
   f.CreatedBy,
   f.CreatedDate,
   f.UpdatedBy,
   f.UpdatedDate
   ,COUNT(*) OVER () AS TotalRecords
  
  FROM dbo.Functions f
  Inner Join Groups g on f.GroupId=g.GroupId

 WHERE (@seaechText = '' OR  LOWER(f.FunctionName) Like  '%'+LOWER(@seaechText) +'%'
  or 
 g.GroupName=@seaechText
 )
  AND f.IsDeleted != 1
  ORDER BY f.CreatedDate DESC
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
