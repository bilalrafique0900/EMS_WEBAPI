using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Application.Contracts.ResponseModel;

namespace EmployeeSystem.Infra.IRepositories.UserManagement
{
    public interface IAuthenticationRepository
    {
        Task<ApiResponseModel> LoginUserAsync(LoginDto loginRequest);
        Task<ApiResponseModel> CheckUser(LoginDto loginRequest);
        Task<bool> ChangePassword(ChangePasswordDto loginRequest);
        Task<bool> ForgotPasswordAsync(string email);
    }
}
