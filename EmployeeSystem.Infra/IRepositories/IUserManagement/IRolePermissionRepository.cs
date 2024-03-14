using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.UserManagement
{
    public interface IRolePermissionRepository : IGenericRepository<PermissionItem>
    {
        Task<bool> SaveRolePermissions(Guid RoleId, string jsonData);
        Task<IEnumerable<RolePermissionDtos>> GetRolePermissions(Guid roleId);
        Task<IEnumerable<RolePermissionDtos>> GetPermissionByRoleIdForLogin(Guid roleId);
    }
}
