using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using System.Data;
using EmployeeSystem.Application.Contracts.DTO;

namespace EmployeeSystem.Infra.Repositories.UserManagement
{
    public class RolePermissionRepository : GenericRepository<PermissionItem>, IRolePermissionRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public RolePermissionRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }
        public async Task<bool> SaveRolePermissions(Guid RoleId, string jsonData)
        {
             _dapper.ExecuteQuery("SaveUpdateRolePermissions", new { @RoleId = RoleId, @Json = jsonData }, CommandType.StoredProcedure);
            return true;
        }
        public async Task<IEnumerable<RolePermissionDtos>> GetRolePermissions(Guid roleId)
        {
            var rec = await _dapper.QueryAsync<RolePermissionDtos>("GetPermissionByRoleId", new { @RoleId = roleId }, CommandType.StoredProcedure).ConfigureAwait(true);
            return rec;
        }
         public async Task<IEnumerable<RolePermissionDtos>> GetPermissionByRoleIdForLogin(Guid roleId)
        {
            var rec = await _dapper.QueryAsync<RolePermissionDtos>("GetPermissionByRoleIdForLogin", new { @RoleId = roleId}, CommandType.StoredProcedure).ConfigureAwait(true);
            return rec;
        }

    }
}
