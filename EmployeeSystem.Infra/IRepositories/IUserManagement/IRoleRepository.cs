using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.UserManagement
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
       Task<bool> CreateUpdate(Role role);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<Role> GetById(Guid roleId);
    }
}
