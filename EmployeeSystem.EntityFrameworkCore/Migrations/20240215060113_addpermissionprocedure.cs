using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addpermissionprocedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE PROCEDURE [dbo].[GetPermissionByRoleIdForLogin]
  @RoleID uniqueidentifier = NULL
AS
BEGIN

	 SELECT 
     rm.PermissionItemId,pitem.Title,pitem.URL,pitem.ParentId,pitem.Code,pitem.Icon,pitem.IsMenuItem ,pitem.SortOrder
     FROM RolePermissions rm 
	 INNER JOIN PermissionItems pitem ON pitem.PermissionItemId = rm.PermissionItemId
	 WHERE rm.RoleId = @RoleID
END
");

            migrationBuilder.Sql(@"
CREATE PROCEDURE [dbo].[GetPermissionByRoleId]
  @RoleID uniqueidentifier = NULL
AS
BEGIN
       SELECT PItem.PermissionItemId,PItem.ParentId,PItem.Title,PItem.URL,PItem.Code,RMOBJ.RoleId,
		CASE WHEN RMOBJ.RoleId IS NOT NULL THEN 1 ELSE 0 END AS IsAssigned
		FROM PermissionItems PItem
		OUTER APPLY (
		SELECT RM.RoleId FROM RolePermissions AS RM
		WHERE PItem.PermissionItemId = RM.PermissionItemId AND RM.RoleId = @RoleID
		) AS RMOBJ
END ;
");
            migrationBuilder.Sql(@"
Create PROCEDURE [dbo].[GetEmployees]
@pageSize int = 10,
@pageNo    int = 1,
@seaechText nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON;
  SELECT
   e.EmployeeId,
   e.EmployeeCode,
   e.FirstName,
   e.MiddleName,
   e.LastName,
   e.Cnic,
   e.Contact,
   e.PersonalEmail,
   e.IsActive,
   e.IsSubmitted
   ,COUNT(*) OVER () AS TotalRecords
  
  FROM dbo.Employees e
 WHERE (@seaechText = '' OR 
 (
 LOWER(e.FirstName + ' ' + e.MiddleName + ' ' + e.LastName) Like  '%'+LOWER(@seaechText) +'%'
 or 
 EmployeeCode=@seaechText
 or 
 Cnic=@seaechText
 or
 Contact=@seaechText
 or
 PersonalEmail=@seaechText))
  AND e.IsDeleted != 1
  ORDER BY e.CreatedDate DESC
  OFFSET ((@pageNo-1) * @pageSize) ROWS
  FETCH NEXT @pageSize ROWS ONLY
END ;

");

            migrationBuilder.Sql(@"
CREATE PROCEDURE [dbo].[SaveUpdateRolePermissions]
  @RoleId uniqueidentifier = NULL,
  @json   nvarchar(max) = ''
AS
BEGIN
   SET NOCOUNT ON ;
	    DELETE FROM RolePermissions WHERE RoleId = @RoleId
		INSERT INTO RolePermissions (RolePermissionId,permissionItemId,RoleId)
		SELECT
        NEWID(),permissionItemId,@RoleId
    FROM OPENJSON(@json)
    WITH (
      RolePermissionId uniqueidentifier,permissionItemId uniqueidentifier
    ) AS j 
END;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
