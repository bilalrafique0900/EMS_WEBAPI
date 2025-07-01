using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using System.Data;
using EmployeeSystem.Application.Contracts.DTO;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace EmployeeSystem.Infra.Repositories.UserManagement
{
    public class JobPermissionRepository : GenericRepository<JobPermission>, IJobPermissionRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public JobPermissionRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }

        public async Task<IEnumerable<JobPermissionDto>> GetJobPermissions()
        {
            var rec = await _dapper.QueryAsync<JobPermissionDto>("GetJobPermissions", new { }, CommandType.StoredProcedure).ConfigureAwait(true);
            return rec;
        }
        public async Task<JobPermission> GetJobPermissionByRoleId(Guid roleId)
        {
            try
            {
                var rec = await _dbContext.JobPermissions.FirstOrDefaultAsync(x => x.RoleId == roleId);
                if (rec != null)
                {
                    return rec;
                }
                else
                {
                    JobPermission obj = new()
                    {
                        JobPermssionId = Guid.NewGuid(),
                        IsJobCreator = false,
                        IsJobApprover = false,
                        IsJobPublisher = false,
                        RoleId = roleId
                    };
                    return obj;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
            }
        
        public async Task<bool> IsJobCreator(Guid roleId, Guid departmentId)
        {
            var rec = await _dbContext.JobPermissions.FirstOrDefaultAsync(x => x.RoleId == roleId && x.DepartmentId == departmentId);
            if (rec != null)
            {
                rec.IsJobCreator = rec.IsJobCreator == true ? false : true;
            }
            else
            {
                JobPermission obj = new()
                {
                    JobPermssionId = Guid.NewGuid(),
                    IsJobCreator = true,
                    IsJobApprover = false,
                    IsJobPublisher = false,
                    RoleId = roleId,
                    DepartmentId = departmentId
                };
                await _dbContext.JobPermissions.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsJobApprover(Guid roleId, Guid departmentId)
        {
            var rec = await _dbContext.JobPermissions.FirstOrDefaultAsync(x => x.RoleId == roleId && x.DepartmentId == departmentId);
            if (rec != null)
            {
                rec.IsJobApprover = rec.IsJobApprover == true ? false : true;
            }
            else
            {
                JobPermission obj = new()
                {
                    JobPermssionId= Guid.NewGuid(),
                    IsJobCreator = false,
                    IsJobApprover = true,
                    IsJobPublisher = false,
                    RoleId = roleId,
                    DepartmentId = departmentId
                };
                await _dbContext.JobPermissions.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IsJobPublisher(Guid roleId, Guid departmentId)
        {
            var rec = await _dbContext.JobPermissions.FirstOrDefaultAsync(x => x.RoleId == roleId && x.DepartmentId == departmentId);
            if (rec != null)
            {
                rec.IsJobPublisher = rec.IsJobPublisher == true ? false : true;
            }
            else
            {
                JobPermission obj = new()
                {
                    JobPermssionId = Guid.NewGuid(),
                    IsJobCreator = false,
                    IsJobApprover = false,
                    IsJobPublisher = true,
                    RoleId = roleId,
                    DepartmentId = departmentId
                };
                await _dbContext.JobPermissions.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
