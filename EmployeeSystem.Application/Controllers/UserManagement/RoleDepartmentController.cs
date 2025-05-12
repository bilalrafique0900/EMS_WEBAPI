using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Infra.IRepositories.IUserManagement;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Controllers.UserManagement
{
    //[Authorize]
    [Route("user-management/roledepartment")]
    [ApiController]
    public class RoleDepartmentController : ControllerBase
    {
        private readonly IRoleDepartmentRepository _roleDepartmentRepository;
        public RoleDepartmentController(IRoleDepartmentRepository roleDepartmentRepository)
        {
            _roleDepartmentRepository = roleDepartmentRepository;
        }
        [HttpGet]
        [Route("roledepartments-list")]
        public async Task<IActionResult> GetRoleDepartments(int pageNo, int pageSize,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _roleDepartmentRepository.GetRoleDepartments(pageNo, pageSize, searchText),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpPost]
        [Route("add-roledepartment")]
        public async Task<IActionResult> Add(RoleDepartmentDto obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            var result = await _roleDepartmentRepository.AddRoleDepartmentAsync(obj);
            var response = new ApiResponseModel
            {
                Status = true,
                Data = result
            };

            return Ok(response);
        }
        [HttpPut]
        [Route("update-roledepartment")]
        public async Task<IActionResult> UpdateUserRoleAsync(RoleDepartmentDto obj)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _roleDepartmentRepository.UpdateRoleDepartmentAsync(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
     
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid departmentId,Guid roleId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data =  _roleDepartmentRepository.Delete(departmentId,roleId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
            }
}
