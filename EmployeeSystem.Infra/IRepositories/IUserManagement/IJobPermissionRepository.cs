using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.UserManagement
{
    public interface IJobPermissionRepository : IGenericRepository<JobPermission>
    {
        Task<IEnumerable<JobPermissionDto>> GetJobPermissions();
        Task<JobPermission> GetJobPermissionByRoleId(Guid roleId);
        Task<bool> IsJobCreator(Guid roleId, Guid departmentId);
        Task<bool> IsJobApprover(Guid roleId, Guid departmentId);
        Task<bool> IsJobPublisher(Guid roleId, Guid departmentId);
    }
}
