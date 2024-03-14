using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeSystem.Infra.Repositories.UserManagement
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public RoleRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }
        public async Task<bool> CreateUpdate(Role role)
        {
            var rec = await _dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == role.RoleId);
            if (rec != null)
            {
                rec.UpdatedDate = DateTime.Now;
                rec.RoleName = role.RoleName;
                rec.DefaultUrl = role.DefaultUrl;
                rec.UpdatedBy = role.CreatedBy;
            }
            else
            {
                Role obj = new()
                {
                    CreatedDate = DateTime.Now,
                    RoleName = role.RoleName,
                    KeyCode = role.KeyCode,
                    CreatedBy = role.CreatedBy,
                    DefaultUrl = role.DefaultUrl,
                    IsActive = true
                };
                await _dbContext.Roles.AddAsync(obj);
            }
           await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted != true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<Role> GetById(Guid roleId)
        {
            IQueryable<Role> query = _dbContext.Roles.Where(p => p.RoleId == roleId);
            Role result = await query.FirstOrDefaultAsync();
            return result;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
            if (rec != null)
            {
                rec.IsActive = !rec.IsActive;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
