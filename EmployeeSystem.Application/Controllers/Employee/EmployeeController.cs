using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Infra.IRepositories.IEmployee;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Repositories.Employee;
using ExcelDataReader;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using OfficeOpenXml;
using System.IO;
using System.Threading.Tasks;
using EmployeeSystem.Infra.IRepositories.ILovType;

namespace EmployeeSystem.Application.Controllers.Employee
{
    [Route("employee/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _EmployeeRepository;

        private readonly IGroupRepository _GroupRepository;
        private readonly ILovTypeRepository _LovTypeRepository;
        public EmployeeController(IEmployeeRepository EmployeeRepository, IGroupRepository GroupRepository, ILovTypeRepository LovTypeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _GroupRepository= GroupRepository;
            _LovTypeRepository = LovTypeRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDto obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            if (obj.Base64 != null)
            {
                string Base64 = "";
                int index = (obj.Base64.IndexOf(","));
                if (index > 0)
                {
                    Base64 = obj.Base64.Substring(index + 1);
                    obj.Picture = CommonMethod.AddFile(Base64, obj.ImagePath);
                }
            }
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.AddUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("get-empcode")]
        public async Task<IActionResult> GetEmployeeCode()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetEmployeeCode(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpGet("get-employees")]
        public async Task<IActionResult> GetEmployees(int pageNo, int pageSize, string searchText = "")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetEmployeesPaginated(pageNo, pageSize, searchText),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpPost, Route("update-education")]
        public async Task<IActionResult> AddUpdateEducation(EmployeeEducationDto obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.AddUpdateEducation(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }



        //[HttpPost("UploadExcelFile")]
        //public IActionResult UploadExcelFile([FromForm] IFormFile File)
        //{
        //    try
        //    {
        //        if (File == null || File.Length == 0)
        //        {
        //            return BadRequest("No file uploaded");
        //        }
        //        var uploadsFolder = $"{ Directory.GetCurrentDirectory()}\\Uploads";
        //        if (!Directory.Exists(uploadsFolder))
        //        {
        //            Directory.CreateDirectory(uploadsFolder);
        //        }
        //        var filePath = Path.Combine(uploadsFolder, File.FileName);
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            File.CopyTo(stream);
        //        }
        //        using (var stream = System.IO. File.Open(filePath, FileMode.Open, FileAccess.Read))
        //        {
                 
        //            using (var reader = ExcelReaderFactory.CreateReader(stream))
        //            {
        //                bool isHeaderSkipped = false;
        //                do
        //                {
        //                    while (reader.Read())
        //                    { 
        //                       if (!isHeaderSkipped)
        //                        {
        //                            isHeaderSkipped = true;
        //                            continue;
        //                        }
        //                       Group e = new Group();
        //                        e.GroupName = reader.GetValue(1).ToString();


        //                        _GroupRepository.CreateUpdate(e);
                               
        //                    }
        //                } while (reader.NextResult()); 
        //            }
        //        }
        //        return Ok("Successfully Inserted");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
        [HttpPost("UploadExcelFile")]
        public async Task<IActionResult> UploadExcel([FromForm] IFormFile File)
        {
            if (File == null || File.Length == 0)
                return BadRequest("No file uploaded.");

            using (var stream = new MemoryStream())
            {
                await File.CopyToAsync(stream);
                stream.Position = 0;

                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Assuming the first row contains headers
                    {

                        var data = new Group
                        {
                            GroupName = worksheet.Cells[row, 1].Value?.ToString(),
                            IsActive = Convert.ToBoolean(worksheet.Cells[row, 2].Value),
                            // Add mappings for other properties
                        };

                        await _GroupRepository.CreateUpdate(data);
                    }
                    
                }
            }

            return Ok("Data imported successfully.");
        }
    [HttpGet("save-education-type")]
        public async Task<IActionResult> SaveEducationType(Guid employeeId,Guid educationTypeId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.SaveEducationType(employeeId,educationTypeId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("get-education")]
        public async Task<IActionResult> GetEducationById(Guid employeeId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetEducationById(employeeId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpPost, Route("update-previous")]
        public async Task<IActionResult> AddUpdatePerivousExperience(EmployeePreviousExperienceDto obj)
        {

            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);


            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.AddUpdatePreviousExperience(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("get-experience")]
        public async Task<IActionResult> GetExperienceById(Guid employeeId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetExperienceById(employeeId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpGet("get-employee-byId")]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetEmployeeById(employeeId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpGet("get-education-byId")]
        public async Task<IActionResult> GetEducationByEducationId(Guid educationId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetEducationByEducationId(educationId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpGet("get-experience-byId")]
        public async Task<IActionResult> GetExperienceByExperienceId(Guid PreviousExperienceId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetExperienceByExperienceId(PreviousExperienceId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> Active(Guid employeeId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.Active(employeeId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpPost, Route("update-family")]
        public async Task<IActionResult> AddUpdateFamily(EmployeeFamilyDto obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.AddUpdateFamily(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpPost, Route("update-children")]
        public async Task<IActionResult> AddUpdateChildren(EmployeeChildrenDto obj)
        {

            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);


            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.AddUpdateChildren(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("get-family")]
        public async Task<IActionResult> GetFamilyById(Guid employeeId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetFamilyById(employeeId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("get-children")]
        public async Task<IActionResult> GetChildrenById(Guid employeeId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetChildrenById(employeeId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpGet("get-family-byId")]
        public async Task<IActionResult> GetFamilyByFamilyId(Guid familyId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetFamilyByFamilyId(familyId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("get-children-byId")]
        public async Task<IActionResult> GetChildrenByChildrenId(Guid ChildrenId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetChildrenByChildrenId(ChildrenId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        //EMPLOYMENT_TYPE
        [HttpGet("get-employees-by-designation")]
        public async Task<IActionResult> GetEmployeesByDesignation(string DesignationCode)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeRepository.GetEmployeesByDesignation(DesignationCode),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

    }
}

