using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface IPostHostRepository : IGenericRepository<PostHost>
    {
        Task<bool> CreateUpdate(PostHost posthost);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<PostHost>> GetAllPostHosts();


    }
}
