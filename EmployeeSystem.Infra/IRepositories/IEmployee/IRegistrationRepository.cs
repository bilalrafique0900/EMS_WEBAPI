using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.EntityFrameworkCore.DBContext;

namespace EmployeeSystem.Infra.IRepositories.IEmployee
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Guid> AddUpdate(EmployeeDto user);
        Task<Guid> AddUpdateEducation(EmployeeEducationDto employee);
        Task<Guid> AddUpdatePreviousExperience(EmployeePreviousExperienceDto user);    
        Task<IEnumerable<EmployeeEducation>> GetEducationById(Guid employeeId);
        Task<IEnumerable<EmployeePreviousExperience>> GetExperienceById(Guid employeeId);
        Task<string> GetEmployeeCode();
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(Guid employeeId);
        Task<EmployeeEducation> GetEducationByEducationId(Guid educationId);
        Task<EmployeePreviousExperience> GetExperienceByExperienceId(Guid PreviousExperienceId);
        Task<IEnumerable<EmployeeListDto>> GetEmployeesPaginated(int pageNo, int pageSize, string searchText);
        Task<bool> Active(Guid employeeId);
        Task<Guid> AddUpdateFamily(EmployeeFamilyDto employee);
        Task<Guid> AddUpdateChildren(EmployeeChildrenDto employee);
        Task<IEnumerable<EmployeeFamily>> GetFamilyById(Guid employeeId);
        Task<IEnumerable<EmployeeChildren>> GetChildrenById(Guid employeeId);
        Task<EmployeeFamily> GetFamilyByFamilyId(Guid familyId);
        Task<EmployeeChildren> GetChildrenByChildrenId(Guid childrenId);
        Task<bool> SaveEducationType(Guid employeeId, Guid educationTypeId);
        Task<IEnumerable<DropdownListDto>> GetEmployeesByDesignation(string DesignationCode);
    }
}
