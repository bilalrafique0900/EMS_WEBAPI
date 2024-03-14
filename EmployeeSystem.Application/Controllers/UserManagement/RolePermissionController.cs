using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using EmployeeSystem.Infra.Repositories.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Controllers.UserManagement
{
    [Authorize]
    [Route("user-management/role-Permission")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {

        private readonly IRolePermissionRepository _rolePermissionRepository;
        public RolePermissionController(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }
        [HttpPost]
        [Route("save-update")]
        public async Task<ActionResult> SaveRolePermissions(RolePermissionDto dto)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _rolePermissionRepository.SaveRolePermissions(dto.RoleId, dto.json.ToString()),
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpGet]
        public async Task<ActionResult> GetPermissionByRole(Guid RoleId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _rolePermissionRepository.GetRolePermissions(RoleId),
                Message = StaticVariables.RecordFounded
            });
        }
    }
}
