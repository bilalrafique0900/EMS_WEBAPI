using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IUserManagement
{
    public interface IRoleDepartmentRepository : IGenericRepository<RoleDepartment>
    {
        Task<bool> AddRoleDepartmentAsync(RoleDepartmentDto user);
        Task<IEnumerable<RoleDepartmentDto>> GetRoleDepartments(int pageNo, int pageSize, string searchText);
        Task<bool> UpdateRoleDepartmentAsync(RoleDepartmentDto user);
        bool Delete(Guid departmentId, Guid roleId);

    }
}
