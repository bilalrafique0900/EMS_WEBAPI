using AutoMapper;
using Dapper;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IJobDescription;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EmployeeSystem.Application.Contracts.ResponseModel;

namespace EmployeeSystem.Infra.Repositories.JobDescription
{
    public class JobDescriptionRepository : GenericRepository<JobDescriptionDto>, IJobDescriptionRepository
    {


        private readonly EmployeeDBContext _dbContext;
        private readonly IMapper _mapper;
        public IDapperConfig _dapper { get; set; }
        public JobDescriptionRepository(EmployeeDBContext appDbContext,IMapper mapper, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _mapper = mapper;
            _dapper = dapper;
        }
        public async Task<bool> CreateUpdate(JobDescriptionDto obj)
        {
            var rec = await _dbContext.JobDescriptions.FirstOrDefaultAsync(x => x.JobDescriptionId == obj.JobDescriptionId);
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
                var StudentMapped = this._mapper.Map<JobDescriptionDto, EmployeeSystem.Domain.Models.JobDescription>(obj);
                await _dbContext.JobDescriptions.AddAsync(StudentMapped);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.JobDescriptions.FirstOrDefaultAsync(x => x.JobDescriptionId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.JobDescriptions.FirstOrDefaultAsync(x => x.JobDescriptionId == id);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Approve(Guid id, Guid ApprovedBy)
        {
            var rec = await _dbContext.JobDescriptions.FirstOrDefaultAsync(x => x.JobDescriptionId == id);
            if (rec != null)
            {
                rec.IsApproved = true;
                rec.ApprovedBy= ApprovedBy;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Publish(Guid id, Guid PublishedBy)
        {
            var rec = await _dbContext.JobDescriptions.FirstOrDefaultAsync(x => x.JobDescriptionId == id);
            if (rec != null)
            {
                rec.IsPublished= true;
                rec.PublishedBy= PublishedBy;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ApiResponseModel> GetAllJobDescriptions(int pageNo, int pageSize, string searchText)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pageNo", pageNo);
            parameters.Add("@pageSize", pageSize);
            parameters.Add("@seaechText", searchText);
            var result = await _dapper.QueryAsync<JobDescriptionDto>("GetJobDescription", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
            return new ApiResponseModel
            {
                Status = true,
                Message = StaticVariables.RecordFounded,
                Data = result
            };
        }
        public async Task<IEnumerable<DropdownListDto>> GetAllJobs()
        {
            List<DropdownListDto> list = await (from job in _dbContext.JobDescriptions
                                                join employee in _dbContext.Employees
                                                on job.JobDescriptionId equals employee.JobDescriptionId into employeeGroup
                                                from employee in employeeGroup.DefaultIfEmpty() // Use left join

                                                where job.IsDeleted != true && job.IsPublished==true && employee == null
                                                select new DropdownListDto
                                                {
                                                    Id = job.JobDescriptionId,
                                                    Name = job.Title + " - (" + job.JobOpeningDate.Value.Date + ")"
                                                }).ToListAsync();

            return list;
        }

        public async Task<bool> CreateUpdate1(JobDescriptionDto obj)
        {
            var rec = await _dbContext.JobDescriptions.FirstOrDefaultAsync(x => x.JobDescriptionId == obj.JobDescriptionId);
            if (rec != null)
            {
                var MapeTheParentObject = this._mapper.Map(obj, rec);
                rec.UpdatedDate = DateTime.Now;

                rec.UpdatedBy = obj.CreatedBy;
            }
            else
            {
                for (var i = 0; i < obj.NumberOfJobs; i++)
                {
                    obj.CreatedDate = DateTime.Now;
                    obj.IsDeleted = false;
                    obj.IsActive = true;
                    obj.JobDescriptionId = Guid.NewGuid();
                    var StudentMapped = this._mapper.Map<JobDescriptionDto, EmployeeSystem.Domain.Models.JobDescription>(obj);
                    await _dbContext.JobDescriptions.AddAsync(StudentMapped);
                }

            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
