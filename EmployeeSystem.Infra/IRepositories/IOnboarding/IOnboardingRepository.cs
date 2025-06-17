using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.EntityFrameworkCore.DBContext;

namespace EmployeeSystem.Infra.IRepositories.IOnboarding
{
    public interface IOnboardingRepository : IGenericRepository<Onboarding>
    {
        Task<bool> CreateUpdate(EmployeeSystem.Domain.Models.Onboarding obj);
        Task<IEnumerable<Onboarding>> GetOnboardings();
        Task<Onboarding> GetOnboardingById(Guid onboardingId);
        Task<string> GetClientCode();
        Task<bool> Delete(Guid onboardingId);
        Task<bool> Active(Guid onboardingId);
        Task<IEnumerable<OnboardingDto>> GetOnboardingsPaginated(int pageNo, int pageSize, string searchText);

        Task<IEnumerable<OnboardingLookupDto>> GetAllBoardings();



    }
}
