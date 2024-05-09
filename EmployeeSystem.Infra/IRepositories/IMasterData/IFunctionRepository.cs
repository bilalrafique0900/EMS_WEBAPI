using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface IFunctionRepository : IGenericRepository<Functions>
    {
        Task<bool> CreateUpdate(Functions function);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<ApiResponseModel> GetAllFunctions(int pageNo, int pageSize, string searchText);
        Task<IEnumerable<Functions>> GetAllFunctions();
        Task<IEnumerable<Functions>> GetFunctionsByGroupId(Guid GroupId);

    }
}
