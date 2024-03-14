using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Controllers.UserManagement
{
    //[Authorize]
    [Route("user-management/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet,Route("user-list")]
        public async Task<IActionResult> GetList()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _userRepository.Find(m => m.IsDeleted != true),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("users-list")]
        public async Task<IActionResult> GetUsers(int pageNo, int pageSize,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _userRepository.GetUsers(pageNo, pageSize, searchText),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _userRepository.Find(x => x.UserId == id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpPost]
        [Route("add-update-user")]
        public async Task<IActionResult> Add(UserDto obj)
        {
            obj. CreatedBy = Guid.Parse(User?.Identity?.Name);
            var result = await _userRepository.AddUserAsync(obj);
            var response = new ApiResponseModel
            {
                Status = true,
                Data = result
            };

            return Ok(response);
        }
        [HttpPut]
        [Route("update-user-role")]
        public async Task<IActionResult> UpdateUserRoleAsync(UserDto obj)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _userRepository.UpdateUserRoleAsync(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto user)
        {
            Guid CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _userRepository.ChangePassword((Guid) user.UserId, CreatedBy, user.Password),
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
                Data = await _userRepository.Delete(id),
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
                Data = await _userRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
