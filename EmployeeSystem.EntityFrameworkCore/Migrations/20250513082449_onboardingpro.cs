using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class onboardingpro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
ALTER PROCEDURE [dbo].[GetOnboardings]  -- execute [dbo].[GetOnboardings]
@pageSize int = 10,
@pageNo    int = 1,
@seaechText nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON;
            SELECT *,
			COUNT(*) OVER() AS TotalRecords
			FROM Onboardings b
			WHERE b.IsDeleted!=1 and ((@seaechText = '' OR b.CompanyName Like  '%'+@seaechText+'%') OR (@seaechText = '' OR b.ContactPersonName Like  '%'+@seaechText+'%') )
  ORDER BY DAY(b.CreatedDate) DESC,
  MONTH(b.CreatedDate) DESC,
  YEAR(b.CreatedDate) DESC
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
