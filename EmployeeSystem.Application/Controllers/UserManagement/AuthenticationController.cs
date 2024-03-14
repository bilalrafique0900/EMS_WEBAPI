using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Controllers.UserManagement
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDto model)
        {
            return Ok(await _authenticationRepository.LoginUserAsync(model));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult> ForgotPassword(string email)
        {
            var result = await _authenticationRepository.ForgotPasswordAsync(email);
            return Ok(new ApiResponseModel
            {
                Status = result,
                Data = result,
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpPost]
        [Route("CheckUser")]
        public async Task<IActionResult> CheckUser(LoginDto user)
        {
                    return Ok(await _authenticationRepository.CheckUser(user));
        }
        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto user)
        {
            bool result = await _authenticationRepository.ChangePassword(user);
            return Ok(new ApiResponseModel
            {
                Status = result,
                Data = result,
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
