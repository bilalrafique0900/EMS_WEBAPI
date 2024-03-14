using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.UserManagement
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> AddUserAsync(UserDto user);
        Task<bool> UpdateUserRoleAsync(UserDto user);
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, LoginDto loginRequest);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<UserDto>> GetUsers(int pageNo, int pageSize, string searchText);
        Task<bool> ChangePassword(Guid userId, Guid updatedUser, string password);
        Task<bool> EmailExistsAsync(string email);
    }
}
