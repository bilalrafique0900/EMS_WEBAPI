using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSystem.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class employeedocumentsprocedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
Create PROCEDURE [dbo].[GetEmployeeAttachmentByReferenceId] @Table NVARCHAR(100) = '',
@TableRefrenceId NVARCHAR(100) = ''
AS
BEGIN

  SET NOCOUNT ON;
  SELECT
    d.TableRefrenceId
   ,d.DocumentId
   ,d.DocumentName DocumentFileName
   ,d.DocumentGuid
   ,d.DocumentSize
   ,d.CreatedDate
   ,sd.DocumentName
   ,sd.IsRequired
  FROM Documents d
  INNER JOIN EmployeeDocuments sd
    ON sd.EmployeeDocumentId = d.LovId
  WHERE d.[Table] = @Table
  AND d.TableRefrenceId = @TableRefrenceId
  AND d.IsDeleted != 1
  order BY d.CreatedDate DESC

END;
");
            migrationBuilder.Sql(@"

Create   PROCEDURE [dbo].[GetEmployeeAttachmentLov]
@LovTypeCode nvarchar(100) = ''
AS
BEGIN

    SET NOCOUNT ON ;
SELECT 
	        lv.LovId,lv.LovName,stdDoc.IsRequired FROM LOVType lvtyp
			INNER JOIN LOVS lv ON lv.LovTypeId = lvtyp.LovTypeId
			INNER JOIN EmployeeDocuments stdDoc ON stdDoc.LovId = lv.LovId
			WHERE lvtyp.LovTypeCode = @LovTypeCode
END ;

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
