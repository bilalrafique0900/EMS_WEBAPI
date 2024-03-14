using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.ILovType
{
    public interface ILovTypeRepository : IGenericRepository<LOVType>
    {
        Task<IEnumerable<LovSelectItemDto>> GetLovTypeByCode(string lovCode);
        Task<IEnumerable<StudentAttachmentDto>> GetStuddentLovByLovCode(string lovCode);
        Task<LovSelectItemDto> GetLovTypeByName(string Name);
    }
}
