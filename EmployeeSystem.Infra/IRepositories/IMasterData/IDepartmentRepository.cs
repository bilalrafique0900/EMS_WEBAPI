using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<bool> CreateUpdate(Department department);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Department>> GetAllDepartments();

    }
}
