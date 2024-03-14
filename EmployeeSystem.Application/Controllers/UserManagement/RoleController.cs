using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Controllers.UserManagement
{
    [Authorize]
    [Route("user-management/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpPost]
        [Route("create-update")]
        public async Task<IActionResult> CreateUpdate(Role obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _roleRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = _roleRepository.GetAll().Where(m=>m.IsDeleted!=true),
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpGet]
        [Route("roles-list")]
        public async Task<IActionResult> GetRoles(int pageNo, int pageSize,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _roleRepository.GetAll(pageNo, pageSize, c => c.IsDeleted != true && c.RoleName.Contains(searchText)),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _roleRepository.Delete(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> Active(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _roleRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
