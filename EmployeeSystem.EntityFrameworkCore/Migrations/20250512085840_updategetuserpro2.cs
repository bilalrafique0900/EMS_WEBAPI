﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class updategetuserpro2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
ALTER PROCEDURE [dbo].[GetUsers]
@pageSize int = 10,
@pageNo    int = 1,
@seaechText nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON;
SELECT 
    us.UserId,
    us.Email,
    us.RoleId,
    us.FullName,
    rl.RoleName,
    us.IsActive,
    us.IsDeleted,
    COALESCE(jp.IsJobCreator, 0) AS IsJobCreator,
    COALESCE(jp.IsJobApprover, 0) AS IsJobApprover,
    COALESCE(jp.IsJobPublisher, 0) AS IsJobPublisher,
    COUNT(*) OVER() AS TotalRecords
FROM 
    Users us
INNER JOIN 
    Roles rl ON rl.RoleId = us.RoleId
LEFT JOIN 
    JobPermissions jp ON jp.RoleId = us.RoleId
WHERE 
    (@seaechText = '' OR us.FullName LIKE '%' + @seaechText + '%')
    OR (@seaechText = '' OR us.Email LIKE '%' + @seaechText + '%')
ORDER BY 
    DAY(us.CreatedDate) DESC,
    MONTH(us.CreatedDate) DESC,
    YEAR(us.CreatedDate) DESC
OFFSET ((@pageNo - 1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

END ;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
