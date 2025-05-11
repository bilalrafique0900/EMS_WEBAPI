using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class updategetjobdescriptionproc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
ALTER PROCEDURE [dbo].[GetJobDescription]
@pageSize int = 10,
@pageNo    int = 1,
@seaechText nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON;
  SELECT
   jd.JobDescriptionId,
   jd.Title,
   jd.DepartmentId,
   d.DepartmentName,
   jd.GroupId,
   g.GroupName,
   jd.HiringManagerId,
   e.FirstName+' '+e.MiddleName+' '+e.LastName as ManagerName,
   jd.EmploymentTypeId,
   employmentType.LovName as EmploymentTypeName,
   jd.PostHostId,
   p.PostHostName,
   jd.Description,
   jd.JobOpeningDate,
   jd.IsActive,
   jd.IsDeleted,
   jd.CreatedBy,
   jd.CreatedDate,
   jd.UpdatedBy,
   jd.UpdatedDate,
    jd.ApprovedBy,
	 jd.IsApproved,
	  jd.PublishedBy,
	   jd.IsPublished
   ,COUNT(*) OVER () AS TotalRecords
  
  FROM dbo.JobDescriptions jd
  Inner Join Departments d on jd.DepartmentId=d.DepartmentId
   Inner Join Employees e on jd.HiringManagerId=e.EmployeeId
    Inner Join Groups g on jd.GroupId=g.GroupId
	 Inner Join PostHosts p on jd.PostHostId=p.PostHostId
	 Inner Join LOVS employmentType on jd.EmploymentTypeId=employmentType.LovId

 WHERE (@seaechText = '' OR  LOWER(jd.Title) Like  '%'+LOWER(@seaechText) +'%')
  AND jd.IsDeleted != 1
  ORDER BY jd.CreatedDate DESC
  OFFSET ((@pageNo-1) * @pageSize) ROWS
  FETCH NEXT @pageSize ROWS ONLY
END ;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
