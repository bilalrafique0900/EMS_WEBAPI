using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface ILevelRepository : IGenericRepository<Level>
    {
        Task<bool> CreateUpdate(Level level);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<DropdownListDto>> GetAllLevels();
        Task<IEnumerable<Level>> GetLevelsByGroupId(Guid GroupId);
        Task<IEnumerable<Level>> GetLevelsByGroupCode(string GroupCode);


    }
}
