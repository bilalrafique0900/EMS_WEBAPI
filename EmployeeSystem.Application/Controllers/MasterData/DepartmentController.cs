using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(Department obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _departmentRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _departmentRepository.GetAllDepartments(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("department-by-groupid")]
        public async Task<IActionResult> GetDepartmentsByGroupId(Guid GroupId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _departmentRepository.GetDepartmentsByGroupId(GroupId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("department-list")]
        public async Task<IActionResult> GetDepartments(int pageNo, int pageSize,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _departmentRepository.GetAllDepartments(pageNo, pageSize, searchText),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _departmentRepository.Delete(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("active/{id}")]
        public async Task<IActionResult> Active(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _departmentRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
