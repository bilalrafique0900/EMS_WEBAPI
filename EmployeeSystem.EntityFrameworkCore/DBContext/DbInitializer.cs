using EmployeeSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.EntityFrameworkCore.DBContext
{
    public class DbInitializer
    {
        private const string ROLE_STUDENT = "STUDENT";
        private const string ROLE_TEACHER = "TEACHER";
        private const string ROLE_PARENT = "PARENT";

        public void Initialize(EmployeeDBContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            #region LovType
            Guid GenderLovTypeId = new("f0cfee10-8d25-488f-b5ea-32431627d224");
            Guid EmployeeStatusLovTypeId = new("5b330bf4-bed9-4c3f-944d-273811d160f7");
            Guid EmployeeLevelLovTypeId = new("F0CFEE10-8D25-488F-B5EA-32431627D223");
            Guid TemplateTypeLovTypeId = new("45678093-a7cb-4ba7-bc21-e332069f27f5");
            Guid MaritalStatusLovTypeId = new("85d789ce-cd32-4847-bc6a-ed28a4297628");

            List<LOVType> lOVTypes = new()
            {
            new LOVType { LovTypeId =  GenderLovTypeId, LovTypeName = "Gender", LovTypeCode = "GENDER" },
            new LOVType { LovTypeId =  EmployeeStatusLovTypeId, LovTypeName = "Employee Status", LovTypeCode = "EMPLOYEE_STATUS" },
            new LOVType { LovTypeId =  EmployeeLevelLovTypeId, LovTypeName = "Level", LovTypeCode = "LEVEL" },
            new LOVType { LovTypeId =  new Guid("76478093-A7CB-4BA7-BC21-E332069F27F5"), LovTypeName = "Employee System", LovTypeCode = "EMPLOYEE_SYSTEM" },
            new LOVType { LovTypeId =  new Guid("62307246-9ACD-4CAA-BFBD-157A11DC09E1"), LovTypeName = "Employee Files", LovTypeCode = "EMPLOYEE_FILES" },
            new LOVType { LovTypeId =  new Guid("9AD0577E-6BB7-4136-A784-D5FDCA9E0205"), LovTypeName = "Employee Type", LovTypeCode = "EMPLOYEE_TYPE" },
            new LOVType { LovTypeId = TemplateTypeLovTypeId, LovTypeName = "Template Type", LovTypeCode = "TEMPLATE_TYPE" },
            new LOVType { LovTypeId = MaritalStatusLovTypeId, LovTypeName = "Marital Status", LovTypeCode = "MARITAL_STATUS" }
            };
            foreach (var item in lOVTypes)
            {
                if (!dbContext.LOVType.Any(m => m.LovTypeCode == item.LovTypeCode))
                {
                    item.IsActive = true;
                    item.CreatedDate = DateTime.Now;
                    dbContext.LOVType.Add(item);
                }
            }
            #endregion
            #region Lov
            List<LOV> Lovs = new()
            {
            //gender
            new LOV { LovId = new Guid("E9B4E7F4-A0C5-4237-9D16-AB504A7CE034"), LovTypeId = GenderLovTypeId, LovName = "Male", LovCode = "MALE" },
            new LOV { LovId = new Guid("CF53B9A7-2B3E-4EDA-8F2D-28A345F26446"), LovTypeId = GenderLovTypeId, LovName = "Female", LovCode = "FEMALE"},

            //student status
            new LOV { LovId = new Guid("0d9e6db2-e6b8-4a1d-850f-1c07517d2d3f"), LovTypeId = EmployeeStatusLovTypeId, LovName = "In Process", LovCode = "IN_PROCESS" },
            new LOV { LovId = new Guid("a4f97db3-1e77-4287-8765-2c2d8ff05455"), LovTypeId = EmployeeStatusLovTypeId, LovName = "No Show", LovCode = "NO_SHOW" },
            new LOV { LovId = new Guid("8b3bef20-c451-4856-b1ac-2136b3686a2f"), LovTypeId = EmployeeStatusLovTypeId, LovName = "On Hold", LovCode = "ON_HOLD" },
            new LOV { LovId = new Guid("a6137bb2-c6b3-4136-9e2a-50653d3e37ba"), LovTypeId = EmployeeStatusLovTypeId, LovName = "On Roll", LovCode = "ON_ROLL" },
            new LOV { LovId = new Guid("f4e308c0-9933-4281-aeb7-b3ea0534568d"), LovTypeId = EmployeeStatusLovTypeId, LovName = "Trial", LovCode = "TRAIL" },
            new LOV { LovId = new Guid("bcaeb393-5f9b-4822-96c0-02dfe4f8e722"), LovTypeId = EmployeeStatusLovTypeId, LovName = "Withdrawn", LovCode = "WITHDRAWN" },

            // level
            new LOV { LovId = new Guid("E9B4E7F4-A0C5-4237-9D16-AB504A7CE032"), LovTypeId =EmployeeLevelLovTypeId, LovName = "Primary", LovCode = "PRIMARY"},
            new LOV { LovId = new Guid("BDB15825-9D9C-40D7-915C-41EBFB6ECA16"), LovTypeId = EmployeeLevelLovTypeId, LovName = "Secondary", LovCode = "SECONDARY"},
            new LOV { LovId = new Guid("49afe94f-910f-48d2-8336-c8d15cf26f46"), LovTypeId = EmployeeLevelLovTypeId, LovName = "Early Years",LovCode="EARLY_YEARS"},
           
            // Employee Type
            new LOV { LovId = new Guid("4D57DF8C-EFD0-4088-A50E-B4B2AB150197"), LovTypeId = new Guid("9AD0577E-6BB7-4136-A784-D5FDCA9E0205"), LovName = "Part Time", LovCode = "PARTTIME"},
            new LOV { LovId = new Guid("BAFA9CF0-8D18-4B8E-8638-E603D920E972"), LovTypeId = new Guid("9AD0577E-6BB7-4136-A784-D5FDCA9E0205"), LovName = "Full Time", LovCode = "FULLTIME"},
            new LOV { LovId = new Guid("e2f23397-7ffc-4d72-a1be-a80335be9624"), LovTypeId = new Guid("9AD0577E-6BB7-4136-A784-D5FDCA9E0205"), LovName = "Paid Internship", LovCode = "PAID_INTERNSHIP"},

 // Marital Status
            new LOV { LovId = new Guid("b514d7c7-ee16-43a9-8818-f366067d3ba1"), LovTypeId =MaritalStatusLovTypeId, LovName = "Single", LovCode = "SINGLE"},
            new LOV { LovId = new Guid("e5f44eba-f2e4-4e1d-910e-619059d33a9a"), LovTypeId =MaritalStatusLovTypeId, LovName = "Married", LovCode = "MARRIED"},
           
            // Employee system
            new LOV { LovId = new Guid("4A919B01-37C4-4E84-A69E-2BB30775F4FF"), LovTypeId = new Guid("76478093-A7CB-4BA7-BC21-E332069F27F5"), LovName = "Digital Omeaga", LovCode = "DIGITALOMEGA"},
            new LOV { LovId = new Guid("E1FF1384-BB93-4DE1-9B5C-93CA225EF2C4"), LovTypeId = new Guid("76478093-A7CB-4BA7-BC21-E332069F27F5"), LovName = "Porocco", LovCode = "POROCCO"},
            // Employee Files
            new LOV { LovId = new Guid("CE6505F5-CD6F-4605-950E-05DC4755FE0B"), LovTypeId = new Guid("62307246-9ACD-4CAA-BFBD-157A11DC09E1"), LovName = "Cnic", LovCode = "CNIC"},
            new LOV { LovId = new Guid("B084956D-9794-4320-BFD9-0DEAD525B4E2"), LovTypeId = new Guid("62307246-9ACD-4CAA-BFBD-157A11DC09E1"), LovName = "Education Document", LovCode = "EDUCATION_DOCUMENT"},
            new LOV { LovId = new Guid("3F245B12-7257-43ED-8B7B-6B5D76CDEC04"), LovTypeId = new Guid("62307246-9ACD-4CAA-BFBD-157A11DC09E1"), LovName = "Previous Experience", LovCode = "PREVIOUS_EXPERIENCE"},
            new LOV { LovId = new Guid("D032DF1F-0A3F-45AA-A227-6CCFA6E29D74"), LovTypeId = new Guid("62307246-9ACD-4CAA-BFBD-157A11DC09E1"), LovName = "Contract", LovCode = "CONTRACT"},
            new LOV { LovId = new Guid("17A2437A-191B-4736-8309-7B98A97B9A28"), LovTypeId = new Guid("62307246-9ACD-4CAA-BFBD-157A11DC09E1"), LovName = "Signature", LovCode = "SIGNATURE"},
            new LOV { LovId = new Guid("82E1816E-C342-4C28-B214-C83779207166"), LovTypeId = new Guid("62307246-9ACD-4CAA-BFBD-157A11DC09E1"), LovName = "HR Policy", LovCode = "HR_POLICY"},
           // Template Types
            new LOV { LovId = new Guid("8460e54d-0f30-432d-9093-610d37a5c1b3"), LovTypeId = TemplateTypeLovTypeId, LovName = "Paper Header", LovCode = "PAPER_HEADER"}

            };
            foreach (var item in Lovs)
            {
                if (!dbContext.LOVS.Any(m => m.LovCode == item.LovCode))
                {
                    item.IsActive = true;
                    item.CreatedDate = DateTime.Now;
                    dbContext.LOVS.Add(item);
                }
            }
            #endregion

            #region User

            Guid EmployeeRoleId = new("f0a8c910-5d91-430c-9e4b-dd814dd28559");
            if (!dbContext.Roles.Any(m => m.KeyCode == "ROLE_EMPLOYEE" && m.RoleId == EmployeeRoleId))
            {
                dbContext.Roles.Add(new Role { RoleId = EmployeeRoleId, RoleName = "Employee", KeyCode = "EMPLOYEE", DefaultUrl = "dashboard/employee", IsSystem = true });
            }

            Guid SuperRoleId = new("1a98be98-f5c9-4290-86f2-08db5916b26f");
            if (!dbContext.Roles.Any(m => m.KeyCode == "SUPER" && m.RoleId == SuperRoleId))
            {
                dbContext.Roles.Add(new Role { RoleId = SuperRoleId, RoleName = "Super", KeyCode = "SUPER", DefaultUrl = "dashboard", IsSystem = true });
            }
            Guid SuperUserId = new("7C156385-0C24-4EF0-5A1E-08DB59173A82");
            if (!dbContext.Users.IgnoreQueryFilters().Any(m => m.RoleId == SuperRoleId && m.UserId == SuperUserId))
            {
                dbContext.Users.Add(new User { UserId = SuperUserId, RoleId = SuperRoleId, Email = "bilal.rana0900@gmail.com", Password = "/HKFaHxX3tw=", IsActive = true, CreatedDate = DateTime.Now });
            }
            #endregion

            #region Permission
            List<PermissionItem> Permissions = new()
            {
            new PermissionItem { PermissionItemId = new Guid("614679C4-0CF0-4AAB-A60C-F11907D2FA85"), Title = "User Management", URL = "#", Code = "USERMANAGEMENT",IsMenuItem = true,SortOrder=100  },
            new PermissionItem { PermissionItemId = new Guid("F4116376-9133-46DA-89A2-9EA42E2FA2BA"), ParentId = new Guid("614679C4-0CF0-4AAB-A60C-F11907D2FA85"), Title = "Roles", URL = "/user-management/role", Code = "ROLE", IsMenuItem = true,SortOrder=101  },
            new PermissionItem { PermissionItemId = new Guid("235BA341-139B-4EF7-9135-98347710AFFD"), ParentId = new Guid("614679C4-0CF0-4AAB-A60C-F11907D2FA85"), Title = "Role Permission", URL = "/user-management/permission", Code = "ROLE_PERMISSION", IsMenuItem = true,SortOrder=102  },
            new PermissionItem { PermissionItemId = new Guid("B85D4143-A42B-45FC-860F-E5B7A103166A"), ParentId = new Guid("614679C4-0CF0-4AAB-A60C-F11907D2FA85"), Title = "Users", URL = "/user-management/user", Code = "USER", IsMenuItem = true ,SortOrder=103 },

            new PermissionItem { PermissionItemId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Master Data", URL = "#", Code = "MASTER_DATA",IsMenuItem = true ,SortOrder=200  },
            new PermissionItem { PermissionItemId = new Guid("CF7305DA-6D87-4988-8999-5BD6E760D131"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Institute", URL = "/master-data/institute", Code = "INSTITUTE", IsMenuItem = true  ,SortOrder=201 },
            new PermissionItem { PermissionItemId = new Guid("34A0C60F-9E9B-421C-BD3C-310BB8566C37"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Branches", URL = "/master-data/institute-branch", Code = "BRANCHES", IsMenuItem = true,SortOrder=202   },
            new PermissionItem { PermissionItemId = new Guid("46FED808-1C80-4134-AA2E-53F5B2B9054D"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Course", URL = "/master-data/course", Code = "COURSE", IsMenuItem = true  ,SortOrder=203 },
            new PermissionItem { PermissionItemId = new Guid("66C48E5F-0D23-44F7-B992-8D0CAD1318EF"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Class", URL = "/master-data/class", Code = "CLASS", IsMenuItem = true  ,SortOrder=204 },
            new PermissionItem { PermissionItemId = new Guid("B2B5362F-55CC-4964-9F03-AEA87EB77B69"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Payment Types", URL = "/master-data/payment-types", Code = "PAYEMENT_TYPE", IsMenuItem = true,SortOrder=205   },
            new PermissionItem { PermissionItemId = new Guid("B30C86AC-B1C7-4A02-96DE-4990DA20B08D"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Terms", URL = "/term-screen/term", Code = "TERMS", IsMenuItem = true  ,SortOrder=206 },
            new PermissionItem { PermissionItemId = new Guid("34a0c60f-9e9b-421c-bd3c-310bb8566c88"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Branch Timings", URL = "/master-data/branch-timings", Code = "BRANCHTIMING", IsMenuItem = true  ,SortOrder=207 },
            new PermissionItem { PermissionItemId = new Guid("34a0c60f-9e9b-421c-bd3c-310bb8566c89"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Rooms", URL = "/master-data/room", Code = "ROOM", IsMenuItem = true  ,SortOrder=208 },

            new PermissionItem { PermissionItemId = new Guid("01524B80-88EC-4B6E-B529-4FECFF085A24"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Zone", URL = "/master-data/zone", Code = "ZONE", IsMenuItem = true  ,SortOrder=209 },
            new PermissionItem { PermissionItemId = new Guid("E0C7DD3C-F555-4BCE-8716-69CCA4B03E58"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Area", URL = "/master-data/area", Code = "AREA", IsMenuItem = true  ,SortOrder=210 },
            new PermissionItem { PermissionItemId = new Guid("35a0c60f-9e9b-421c-bd3c-310bb8566c90"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Template", URL = "/master-data/template", Code = "TEMPLATE", IsMenuItem = true  ,SortOrder=211 },
            new PermissionItem { PermissionItemId = new Guid("66c48e5f-0d23-44f7-b992-8d0cad1320ef"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Class Courses", URL = "/master-data/class-courses", Code = "CLASS_COURSES", IsMenuItem = false  ,SortOrder=212 },
            new PermissionItem { PermissionItemId = new Guid("089bb195-4bfc-4b37-b6a5-ccb836c555f3"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Section", URL = "/master-data/section", Code = "SECTION", IsMenuItem = true  ,SortOrder=213 },
            new PermissionItem { PermissionItemId = new Guid("00c7d705-76ee-4f10-b699-8ca2e69c9295"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Class Section", URL = "/master-data/class-section", Code = "CLASS_SECTION", IsMenuItem = false  ,SortOrder=214 },
            new PermissionItem { PermissionItemId = new Guid("fd78f8f4-d11a-4379-862d-dbade67c83f1"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Discount", URL = "/master-data/discount", Code = "DISCOUNT", IsMenuItem = true  ,SortOrder=215 },
            new PermissionItem { PermissionItemId = new Guid("9e56f175-71ee-4b83-8e07-89150104f44c"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Student Document", URL = "/master-data/student-document", Code = "STUDENT_DOCUMENT", IsMenuItem = true  ,SortOrder=216 },
            new PermissionItem { PermissionItemId = new Guid("7A371454-5009-4723-8C6A-1CAEEC492793"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Payment Type Sap Config", URL = "/master-data/Payment-type-sap-config", Code = "PAYEMENT_TYPE_SAP-CONFIG", IsMenuItem = false  ,SortOrder=217 },
            new PermissionItem { PermissionItemId = new Guid("6353A719-CC53-4118-8242-7156BCBDA7A9"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Acadmic Year", URL = "/master-data/acadmic-year", Code = "ACADMIC_YEAR", IsMenuItem = true  ,SortOrder=218 },
            new PermissionItem { PermissionItemId = new Guid("FA88F113-DC35-42E5-83A9-FD907E675C80"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Gradding System", URL = "/master-data/grading-system", Code = "GRADDING_SYSTEM", IsMenuItem = true  ,SortOrder=219 },
            new PermissionItem { PermissionItemId = new Guid("86af3097-b32e-4948-aef6-a4005faa7582"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Attendance Config", URL = "/master-data/attendance-config", Code = "ATTENDANCE_CONFIG", IsMenuItem = true  ,SortOrder=220 },
            new PermissionItem { PermissionItemId = new Guid("b7f5e516-6b62-40c6-bb8d-9dfd345dd2d0"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Marks Policy", URL = "/master-data/marks-policy", Code = "MARKS_POLICY", IsMenuItem = true  ,SortOrder=221 },
            new PermissionItem { PermissionItemId = new Guid("c66ca1f2-c4dc-441b-a2c6-49f7455df86f"), ParentId = new Guid("448AAB52-72DF-4E21-B3DE-0C4C82F96DB1"), Title = "Reports", URL = "/master-data/reports-config", Code = "MASTER_REPORTS", IsMenuItem = true  ,SortOrder=222 },



            new PermissionItem { PermissionItemId = new Guid("9117d8b4-131f-4193-8dde-a25e18f23de5"), Title = "Dashboard", URL = "/dashboard", Code = "ADMIN_DASHBOARD",Description=" For Admin",IsMenuItem = true,SortOrder=300  },
            new PermissionItem { PermissionItemId = new Guid("e236be01-7392-4811-9324-57acebc75df7"), Title = "Dashboard", URL = "/dashboard/student", Code = "STUDENT_DASHBOARD",Description="Only for Student",IsMenuItem = true,SortOrder=301  },
            new PermissionItem { PermissionItemId = new Guid("2d530915-7773-44a0-9029-daf4f57f4a66"), Title = "Dashboard", URL = "/dashboard/teacher", Code = "TEACHER_DASHBOARD",Description="Only for Teacher",IsMenuItem = true,SortOrder=302  },
            new PermissionItem { PermissionItemId = new Guid("da999e8f-5514-4fdb-9e9f-e863201baf2d"), Title = "Dashboard", URL = "/dashboard/user", Code = "USER_DASHBOARD",Description="Only for Users",IsMenuItem = true,SortOrder=303  },



            new PermissionItem { PermissionItemId = new Guid("C623E57E-F190-4492-88A4-B6F57647595B"), Title = "Student", URL = "#", Code = "STUDENT",IsMenuItem = true,SortOrder=400  },
            new PermissionItem { PermissionItemId = new Guid("197CB995-9E22-47E2-93C4-40A2C09AF613"), ParentId = new Guid("C623E57E-F190-4492-88A4-B6F57647595B"), Title = "Student Registration", URL = "/registration/student", Code = "STUDENT_REGISTRATION", IsMenuItem = true ,SortOrder=401 },
            new PermissionItem { PermissionItemId = new Guid("663F250A-1A97-4544-BA2E-7A07B7FDBD20"), ParentId = new Guid("C623E57E-F190-4492-88A4-B6F57647595B"), Title = "Student List", URL = "/registration/student-list", Code = "STUDENT_LIST", IsMenuItem = true  ,SortOrder=402},

             new PermissionItem { PermissionItemId = new Guid("2065C440-7EC4-44A4-843C-FF2E273F5781"), Title = "Approvals", URL = "#", Code = "APPROVALS",IsMenuItem = true,SortOrder=500  },
             new PermissionItem { PermissionItemId = new Guid("1CCC4C41-A5F6-4E31-B684-F309648CE655"), ParentId = new Guid("2065C440-7EC4-44A4-843C-FF2E273F5781"), Title = "Approval Configuration", URL = "/approval-mechanism/approval-configuration", Code = "APPROVAL_CONFIGURATION", IsMenuItem = true ,SortOrder=501 },
             new PermissionItem { PermissionItemId = new Guid("B73F4CE1-6A35-420F-BFB3-5AF59990CDD8"), ParentId = new Guid("2065C440-7EC4-44A4-843C-FF2E273F5781"), Title = "User Approvals", URL = "/approval-mechanism/approval", Code = "USER_APPROVAL", IsMenuItem = true  ,SortOrder=502},
             new PermissionItem { PermissionItemId = new Guid("1ccc4c41-a5f6-4e31-b684-f309648ce750"), ParentId = new Guid("2065C440-7EC4-44A4-843C-FF2E273F5781"), Title = "Approval History", URL = "/approval-mechanism/approval-history", Code = "APPROVAL_HISTORY", IsMenuItem = true  ,SortOrder=503},

             new PermissionItem { PermissionItemId = new Guid("41B00952-B6F0-40AF-A693-3B7028B6548F"), Title = "Finance", URL = "#", Code = "FINANCE",IsMenuItem = true ,SortOrder=600 },
             new PermissionItem { PermissionItemId = new Guid("C7AA6B25-E4D2-4AF3-B32B-5477361E9CF3"), ParentId = new Guid("41B00952-B6F0-40AF-A693-3B7028B6548F"), Title = "New Students", URL = "/finance/new-students", Code = "FINANCE_NEW_STUDENTS", IsMenuItem = true,SortOrder=601  },
             new PermissionItem { PermissionItemId = new Guid("c5d81638-43c0-44e7-bfe0-800e5bdf4c18"), ParentId = new Guid("41B00952-B6F0-40AF-A693-3B7028B6548F"), Title = "Add Payments", URL = "/finance/add-student-payment", Code = "FINANCE_ADD_PAYMENTS", IsMenuItem = false,SortOrder=602  },
             new PermissionItem { PermissionItemId = new Guid("3367a9b4-efa4-4e4e-bdad-eaafd5c18a97"), ParentId = new Guid("41B00952-B6F0-40AF-A693-3B7028B6548F"), Title = "Fee Vouchers", URL = "/finance/student-payments", Code = "STUDENT_PAYMENTS", IsMenuItem = true  ,SortOrder=603},
             new PermissionItem { PermissionItemId = new Guid("e1a825b3-248c-479f-b1e6-26651f13736f"), ParentId = new Guid("41B00952-B6F0-40AF-A693-3B7028B6548F"), Title = "SAP LOGS", URL = "/finance/sap-logs", Code = "SAP_LOGS", IsMenuItem = true  ,SortOrder=604},



             new PermissionItem { PermissionItemId = new Guid("B8985FB3-79A2-4544-8ACE-822AF222FABB"), Title = "IT", URL = "#", Code = "IT",IsMenuItem = true ,SortOrder=700 },
             new PermissionItem { PermissionItemId = new Guid("714B3462-904B-46CD-913F-387A7E8C6026"), ParentId = new Guid("B8985FB3-79A2-4544-8ACE-822AF222FABB"), Title = "New Students", URL = "/it/new-students", Code = "IT_NEW_STUDENTS", IsMenuItem = true,SortOrder=701  },
             new PermissionItem { PermissionItemId = new Guid("714B3462-904B-46CD-913F-387A7E8C6027"), ParentId = new Guid("B8985FB3-79A2-4544-8ACE-822AF222FABB"), Title = "Add Users", URL = "/it/add-student-user", Code = "IT_NEW_STUDENT_USER", IsMenuItem = false,SortOrder=702  },
             new PermissionItem { PermissionItemId = new Guid("94260316-edb0-426c-8225-279cb60959e6"), ParentId = new Guid("B8985FB3-79A2-4544-8ACE-822AF222FABB"), Title = "New Teachers", URL = "/it/new-teachers", Code = "IT_NEW_TEACHERS", IsMenuItem = true,SortOrder=703  },
             new PermissionItem { PermissionItemId = new Guid("b02ce34f-f8cc-45be-b702-bd1fb326bf17"), ParentId = new Guid("B8985FB3-79A2-4544-8ACE-822AF222FABB"), Title = "Add Users", URL = "/it/add-teacher-user", Code = "IT_NEW_TEACHER_USER", IsMenuItem = false,SortOrder=704  },

            new PermissionItem { PermissionItemId = new Guid("4E10A91C-0B0D-4806-84F9-7C0A66B8297A"), Title = "Assignment & Quiz", URL = "#", Code = "ASSIGNMENT_QUIZ",IsMenuItem = true ,SortOrder=800 },
            new PermissionItem { PermissionItemId = new Guid("F1C964C6-2F28-484B-89BA-E926514F79C5"), ParentId = new Guid("4E10A91C-0B0D-4806-84F9-7C0A66B8297A"), Title = "Upload", URL = "/assignement/assignment", Code = "ASSIGNMENT_QUIZ", IsMenuItem = true ,SortOrder=801  },
            new PermissionItem { PermissionItemId = new Guid("6DC5B0CE-D642-4F99-AE88-C0E457729F69"), ParentId = new Guid("4E10A91C-0B0D-4806-84F9-7C0A66B8297A"), Title = "Student Assignment & Quiz",Description="Only for Student", URL = "/assignement/student-assignment", Code = "ASSIGNMENT_QUIZ_STUDENT", IsMenuItem = true ,SortOrder=802  },

            new PermissionItem { PermissionItemId = new Guid("2065c440-7ec4-44a4-843c-ff2e273f9981"), Title = "Teacher", URL = "#", Code = "TEACHER",IsMenuItem = true,SortOrder=900  },
            new PermissionItem { PermissionItemId = new Guid("2065c440-7ec4-44a4-843c-ff2e333f9981"), ParentId = new Guid("2065c440-7ec4-44a4-843c-ff2e273f9981"), Title = "Teacher List", URL = "/teacher/teacher-list", Code = "TEACHER_LIST", IsMenuItem = true ,SortOrder=901 },
            new PermissionItem { PermissionItemId = new Guid("2065c440-7ec4-44a4-843c-ff2e333f9982"), ParentId = new Guid("2065c440-7ec4-44a4-843c-ff2e273f9981"), Title = "Teacher Classes", URL = "/teacher/teacher-classes", Code = "TEACHER_CLASSES", IsMenuItem = false ,SortOrder=902 },
            new PermissionItem { PermissionItemId = new Guid("2065c440-7ec4-44a4-843c-ff2e333f9983"), ParentId = new Guid("2065c440-7ec4-44a4-843c-ff2e273f9981"), Title = "Teacher Courses", URL = "/teacher/teacher-courses", Code = "TEACHER_COURSES", IsMenuItem = false ,SortOrder=903 },

            new PermissionItem { PermissionItemId = new Guid("788995ce-1aee-4338-bd4a-4f2e06c86d99"), Title = "Timetable", URL = "#", Code = "TIMETABLE",IsMenuItem = true,SortOrder=1000  },
            new PermissionItem { PermissionItemId = new Guid("54ffdcef-a98e-4ce7-ba8c-dbc7edb0b3b6"), ParentId = new Guid("788995ce-1aee-4338-bd4a-4f2e06c86d99"), Title = "Timetable List", URL = "/timetable", Code = "TIMETABLE_LIST", IsMenuItem = true ,SortOrder=1001 },
            new PermissionItem { PermissionItemId = new Guid("5772a28c-d221-4b63-9f6a-1db592b896ab"), ParentId = new Guid("788995ce-1aee-4338-bd4a-4f2e06c86d99"), Title = "Generate", URL = "/timetable/generate", Code = "TIMETABLE_GENERATE", IsMenuItem = true ,SortOrder=1001 },
            new PermissionItem { PermissionItemId = new Guid("4e839c8b-670b-4bbf-a32b-73f1de0bc445"), ParentId = new Guid("788995ce-1aee-4338-bd4a-4f2e06c86d99"), Title = "Student Locator", URL = "/timetable/student-locator", Code = "TIMETABLE_STUDENT_LOCATOR", IsMenuItem = true ,SortOrder=1002 },
            new PermissionItem { PermissionItemId = new Guid("38505d50-f50c-4219-88e6-03541965c1ff"), ParentId = new Guid("788995ce-1aee-4338-bd4a-4f2e06c86d99"), Title = "Teacher Timetable", URL = "/timetable/teacher", Code = "TIMETABLE_TEACHER", IsMenuItem = true ,SortOrder=1003 },


            new PermissionItem { PermissionItemId = new Guid("D0607C46-B939-4914-A873-16D88B324A76"), Title = "Attendance", URL = "#", Code = "ATTENDANCE",IsMenuItem = true,SortOrder=1100  },
            new PermissionItem { PermissionItemId = new Guid("5FD92589-9A5C-4E84-8439-BB3725542FDE"), ParentId = new Guid("D0607C46-B939-4914-A873-16D88B324A76"), Title = "Attendance", URL = "/attendance", Code = "ATTENDANCE_LIST", IsMenuItem = true ,SortOrder=1001 },
            new PermissionItem { PermissionItemId = new Guid("D9BFA0EB-06E9-4F5F-BE87-4FC690178031"), ParentId = new Guid("D0607C46-B939-4914-A873-16D88B324A76"), Title = "Course Attendance", URL = "/attendance/course-attendance", Code = "COURSE-ATTENDANCE", IsMenuItem = true ,SortOrder=1002 },
            new PermissionItem { PermissionItemId = new Guid("4FF3CB60-8A4F-40CB-977A-9155B294AD31"), ParentId = new Guid("D0607C46-B939-4914-A873-16D88B324A76"), Title = "Course Attendance List", URL = "/attendance/course-attendance-list", Code = "COURSE-ATTENDANCE-LIST", IsMenuItem = true ,SortOrder=1003 },
            new PermissionItem { PermissionItemId = new Guid("76daf09b-245f-4abe-aa03-ad719d76e213"), ParentId = new Guid("D0607C46-B939-4914-A873-16D88B324A76"), Title = "Import From Machine", URL = "#", Code = "ATTENDANCE_IMPORT", IsMenuItem = false ,SortOrder=1004 },

            new PermissionItem { PermissionItemId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Examination", URL = "#", Code = "EXAMINATION",IsMenuItem = true,SortOrder=1200  },
            new PermissionItem { PermissionItemId = new Guid("617052CA-2C0F-49D4-83F3-B840BE5C8B45"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Questions", URL = "/examination/question", Code = "QUESTION", IsMenuItem = true ,SortOrder=1201 },
            new PermissionItem { PermissionItemId = new Guid("272DAF14-9494-4F4C-8468-C69CDF424323"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Papers", URL = "/examination/paper", Code = "PAPER", IsMenuItem = true ,SortOrder=1203 },
            new PermissionItem { PermissionItemId = new Guid("30c8eecf-d17b-4e78-b58e-4ae18057d1e2"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Marks Generation", URL = "/examination/marks", Code = "EXAM_MARKS", IsMenuItem = false ,SortOrder=1203 },
            new PermissionItem { PermissionItemId = new Guid("6d430200-c688-47bf-bdf2-a2e986278b84"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Marks", URL = "/examination/marks-list", Code = "EXAM_MARKS_LIST", IsMenuItem = true ,SortOrder=1204 },
            new PermissionItem { PermissionItemId = new Guid("f276f165-f883-4939-bb0d-0a1f4789048a"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Student Marks",Description="Only for Students", URL = "/examination/student-marks", Code = "EXAM_STUDENT_MARKS", IsMenuItem = true ,SortOrder=1205 },
            new PermissionItem { PermissionItemId = new Guid("b72266ba-7908-4ad3-9f66-f1b00f770ff3"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Student Barcode", URL = "/examination/student-barcode", Code = "EXAM_STUDENT_BARCODE", IsMenuItem = true ,SortOrder=1206 },
            new PermissionItem { PermissionItemId = new Guid("e82f7135-a2b5-4be1-ad6c-637cee55043d"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Result", URL = "/examination/result", Code = "EXAM_RESULT", IsMenuItem = true ,SortOrder=1207 },
            new PermissionItem { PermissionItemId = new Guid("df728643-c9eb-4a37-a518-a8ec961e0385"), ParentId = new Guid("29B62637-9D62-462F-9D57-A70C6843384E"), Title = "Paper Timetable", URL = "/examination/paper-time-table", Code = "EXAM_PAPER_TIMETABLE", IsMenuItem = true ,SortOrder=1208 },



             new PermissionItem { PermissionItemId = new Guid("2d227463-43d6-4e25-a0bf-17c779a4d9dc"), Title = "Events", URL = "/events", Code = "EVENTS",IsMenuItem = true,SortOrder=1200  },


            new PermissionItem { PermissionItemId = new Guid("f1871ce2-0648-4a66-acb9-ae491448dbd2"), Title = "News", URL = "/news", Code = "NEWS",IsMenuItem = true,SortOrder=1300  },
            };
            foreach (var item in Permissions)
            {
                if (!dbContext.PermissionItems.Any(m => m.Code == item.Code))
                {
                    item.CreatedDate = DateTime.Now;
                    item.IsActive = true;
                    dbContext.PermissionItems.Add(item);

                }
                if (!dbContext.RolePermissions.Any(m => m.RoleId == SuperRoleId && m.PermissionItemId == item.PermissionItemId))
                {
                    dbContext.RolePermissions.Add(new RolePermission { RolePermissionId = Guid.NewGuid(), RoleId = SuperRoleId, PermissionItemId = item.PermissionItemId });
                }
            }
            #endregion

            dbContext.SaveChanges();
        }
    }
}
