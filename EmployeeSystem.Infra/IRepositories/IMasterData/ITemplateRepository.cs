using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface ITemplateRepository : IGenericRepository<Template>
    {
        Task<bool> CreateUpdate(Template template);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Template>> GetAllTemplates();
        Task<IEnumerable<Template>> GetByKeycods(string[] ForKeyCodes);

    }
}
