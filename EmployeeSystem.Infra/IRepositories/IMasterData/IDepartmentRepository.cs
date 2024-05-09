using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<bool> CreateUpdate(Department department);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<ApiResponseModel> GetAllDepartments(int pageNo, int pageSize, string searchText);
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<IEnumerable<Department>> GetDepartmentsByGroupId(Guid GroupId);

    }
}
