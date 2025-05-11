using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.EntityFrameworkCore.DBContext;

namespace EmployeeSystem.Infra.IRepositories.IJobDescription
{
    public interface IJobDescriptionRepository : IGenericRepository<JobDescriptionDto>
    {
        Task<bool> CreateUpdate(JobDescriptionDto jobDescription);
        Task<bool> CreateUpdate1(JobDescriptionDto obj);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Approve(Guid id,Guid ApprovedBy);
        Task<bool> Publish(Guid id,Guid PublishedBy);
        Task<ApiResponseModel> GetAllJobDescriptions(int pageNo, int pageSize, string searchText);
        Task<IEnumerable<DropdownListDto>> GetAllJobs();
    }
}
