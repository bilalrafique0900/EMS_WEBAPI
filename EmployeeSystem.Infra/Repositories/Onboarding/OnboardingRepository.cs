using AutoMapper;
using Dapper;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IEmployee;  
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using EmployeeSystem.Infra.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using EmployeeSystem.Infra.IRepositories.IOnboarding;

namespace EmployeeSystem.Infra.Repositories.Onboarding
{
    public class OnboardingRepository : GenericRepository<Domain.Models.Onboarding>, IOnboardingRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly IMapper _mapper;
        public IDapperConfig _dapper { get; set; }
        private readonly ILogger _logger;
        private readonly IHubContext<NotificationHub> _hub;
        public OnboardingRepository(EmployeeDBContext appDbContext, IMapper mapper, IDapperConfig dapper
            , ILogger<OnboardingRepository> logger
            , IHubContext<NotificationHub> hub) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _mapper = mapper;
            _logger = logger;
            _hub = hub;
            
        }
        public async Task<bool> CreateUpdate(EmployeeSystem.Domain.Models.Onboarding obj)
        {
            var rec = await _dbContext.Onboardings.FirstOrDefaultAsync(x => x.OnboardingId == obj.OnboardingId);
            if (rec != null)
            {
                var MapeTheParentObject = this._mapper.Map(obj, rec);
                rec.UpdatedDate = DateTime.Now;

                rec.UpdatedBy = obj.CreatedBy;
            }
            else
            {
               
                    obj.CreatedDate = DateTime.Now;
                    obj.IsDeleted = false;
                    obj.IsActive = true;
                    obj.OnboardingId = Guid.NewGuid();
                   // var StudentMapped = this._mapper.Map<OnboardingDto, EmployeeSystem.Domain.Models.Onboarding>(obj);
                    await _dbContext.Onboardings.AddAsync(obj);
                }

            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<Domain.Models.Onboarding> GetOnboardingById(Guid onboardingId)
        {
            var OnboardingRecordFormDB = await _dbContext.Onboardings.Where(x => x.OnboardingId == onboardingId).FirstOrDefaultAsync();
            return OnboardingRecordFormDB;
        }

        public async Task<IEnumerable<Domain.Models.Onboarding>> GetOnboardings()
        {
            var OnboardingRecordFormDB = await _dbContext.Onboardings.ToListAsync();
         
                return OnboardingRecordFormDB;
        }
        private static string CheckValidDate(DateTime? date)
        {
            DateTime temp;
            if (DateTime.TryParse(date.ToString(), out temp))
            {
                return temp.ToString("yyyyMMdd");
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Active(Guid onboardingId)
        {
            var rec = await _dbContext.Onboardings.FirstOrDefaultAsync(x => x.OnboardingId == onboardingId);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<OnboardingDto>> GetOnboardingsPaginated(int pageNo, int pageSize, string searchText)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pageNo", pageNo);
            parameters.Add("@pageSize", pageSize);
            parameters.Add("@seaechText", searchText);

            var Onboarding = await _dapper.QueryAsync<OnboardingDto>("GetOnboardings", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
            return Onboarding;
        }



    }
}
