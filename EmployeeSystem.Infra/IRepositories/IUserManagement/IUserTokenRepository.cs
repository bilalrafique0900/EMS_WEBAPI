using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IUserManagement
{
    public interface IUserTokenRepository
    {
        Task<UserToken> GetByUserIdAsync(Guid userId);
        Task<UserToken> AddUpdate( UserToken userToken);
        Task<IEnumerable<UserTokenDto>> GetStudentToken();
        Task<IEnumerable<UserTokenDto>> GetAssignmentStudentToken(Guid assignmentId);
        Task<IEnumerable<UserTokenDto>> GetParentToken();
    }
}
