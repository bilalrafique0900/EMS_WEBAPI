using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Infra.IRepositories.IUserManagement;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using EmployeeSystem.Infra.Repositories.UserManagement;

namespace EmployeeSystem.Controllers.UserManagement
{
    //[Authorize]
    [Route("user-management/jobpermission")]
    [ApiController]
    public class JobPermissionController : ControllerBase
    {
        private readonly IJobPermissionRepository _jobPermissionRepository;
        public JobPermissionController(IJobPermissionRepository jobPermissionRepository)
        {
            _jobPermissionRepository = jobPermissionRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetJobPermissions()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobPermissionRepository.GetJobPermissions(),
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpGet]
        [Route("isjobcreator")]
        public async Task<ActionResult> IsJobCreator(Guid roleId, Guid departmentId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobPermissionRepository.IsJobCreator(roleId, departmentId),
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpGet]
        [Route("isjobapprover")]
        public async Task<ActionResult> IsJobApprover(Guid roleId, Guid departmentId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobPermissionRepository.IsJobApprover(roleId, departmentId),
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpGet]
        [Route("isjobpublisher")]
        public async Task<ActionResult> IsJobPublisher(Guid roleId, Guid departmentId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _jobPermissionRepository.IsJobPublisher(roleId, departmentId),
                Message = StaticVariables.RecordFounded
            });
        }
    }
}