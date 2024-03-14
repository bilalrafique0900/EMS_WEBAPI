using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.IRepositories.IMasterData
{
    public interface IEmployeeDocumentRepository : IGenericRepository<EmployeeDocument>
    {
        Task<bool> CreateUpdate(EmployeeDocument document);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<EmployeeDocument>> GetAllEmployeeDocuments();
        Task<bool> IsRequired(Guid id);
    }
}
