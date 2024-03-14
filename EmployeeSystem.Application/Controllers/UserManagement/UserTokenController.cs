using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IUserManagement;

namespace EmployeeSystem.Controllers.UserManagement
{
    //[Authorize]
    [Route("user-management/users/{userId}/token")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        private readonly IUserTokenRepository _userTokenRepository;
        public UserTokenController(IUserTokenRepository userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _userTokenRepository.GetByUserIdAsync(userId),
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserToken userToken)
        {
            var result =  await _userTokenRepository.AddUpdate(userToken);
            var response = new ApiResponseModel
            {
                Status = true,
                Data = result
            };

            return Ok(response);
        }
        
    }
}
