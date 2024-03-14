using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<bool> CreateUpdate(Group group);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<DropdownListDto>> GetAllGroups();


    }
}
