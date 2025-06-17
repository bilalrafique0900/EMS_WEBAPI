using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Ocsp;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using iText.Commons.Actions.Contexts;
using EmployeeSystem.Infra.IRepositories.IUserManagement;
using EmployeeSystem.EntityFrameworkCore.Migrations;
using StackExchange.Redis;
using Microsoft.Data.SqlClient;

namespace EmployeeSystem.Infra.Repositories.UserManagement
{
    public class RoleDepartmentRepository : GenericRepository<RoleDepartment>, IRoleDepartmentRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly ILogger _logger;
        public IDapperConfig _dapper { get; set; }
        public RoleDepartmentRepository(EmployeeDBContext appDbContext, IDapperConfig dapper, ILogger<UserRepository> logger) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _logger = logger;
        }

        public async Task<bool> AddRoleDepartmentAsync1(RoleDepartmentDto user)
        {
            if (user.DepartmentId != null)
            {
                IQueryable<RoleDepartment> query = _dbContext.RoleDepartments.IgnoreQueryFilters().Where(p => p.DepartmentId == user.DepartmentId && p.RoleId==user.RoleId);
                RoleDepartment result = await query.FirstOrDefaultAsync();
                if (result != null)
                {
                    result.RoleId = user.RoleId;
                    result.DepartmentId = user.DepartmentId;
                
                }
                else
                {
                    var usr = new RoleDepartment
                    {
                        
                        RoleId = user.RoleId,
                        DepartmentId = user.DepartmentId
                       
                    };

                    _dbContext.Entry(usr).State = EntityState.Added;
                    //await _dbContext.RoleDepartments.AddAsync(usr);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AddRoleDepartmentAsync(RoleDepartmentDto user)
        {
            if (user.DepartmentId != null)
            {
                // Check if the record exists using LINQ
                var exists = await _dbContext.RoleDepartments
                    .IgnoreQueryFilters() // optional
                    .AnyAsync(r => r.RoleId == user.RoleId && r.DepartmentId == user.DepartmentId);

                if (!exists)
                {
                    // Insert if not exists
                    var insertQuery = @"
                INSERT INTO RoleDepartments (RoleId, DepartmentId) 
                VALUES (@RoleId, @DepartmentId)";

                    await _dbContext.Database.ExecuteSqlRawAsync(insertQuery,
                        new SqlParameter("@RoleId", user.RoleId),
                        new SqlParameter("@DepartmentId", user.DepartmentId));
                }
                else
                {
                    // Update — add any fields you may need to update
                    var updateQuery = @"
                UPDATE RoleDepartments 
                SET RoleId = @RoleId, DepartmentId = @DepartmentId
                WHERE RoleId = @RoleId AND DepartmentId = @DepartmentId";

                    await _dbContext.Database.ExecuteSqlRawAsync(updateQuery,
                        new SqlParameter("@RoleId", user.RoleId),
                        new SqlParameter("@DepartmentId", user.DepartmentId));
                }

                return true;
            }

            return false;
        }




        public async Task<IEnumerable<RoleDepartmentDto>> GetRoleDepartments(int pageNo, int pageSize, string searchText)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pageNo", pageNo);
            parameters.Add("@pageSize", pageSize);
            parameters.Add("@seaechText", searchText);
            return await _dapper.QueryAsync<RoleDepartmentDto>("GetRoleDepartments", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
        }
        public async Task<bool> UpdateRoleDepartmentAsync(RoleDepartmentDto user)
        {
            var rec = await _dbContext.RoleDepartments.Where(x => x.DepartmentId == user.DepartmentId && x.RoleId==user.RoleId).FirstOrDefaultAsync();
            if (rec != null)
            {
                rec.RoleId = user.RoleId;
                rec.DepartmentId = user.DepartmentId;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

       
        public bool Delete(Guid departmentId,Guid roleId)
        {
            var deleteQuery = @"
                DELETE FROM RoleDepartments 
                WHERE RoleId = @RoleId AND DepartmentId = @DepartmentId";
             _dbContext.Database.ExecuteSqlRaw(deleteQuery,
                new SqlParameter("@RoleId", roleId),
                new SqlParameter("@DepartmentId", departmentId));
            return true;
        }

    }
}
