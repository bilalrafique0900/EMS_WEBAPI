using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeSystem.Infra.Repositories.MasterData
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public DepartmentRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }
        public async Task<bool> CreateUpdate(Department obj)
        {
            var rec = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == obj.DepartmentId);
            if (rec != null)
            {
                rec.UpdatedDate = DateTime.Now;
                rec.DepartmentName = obj.DepartmentName;
                rec.UpdatedBy = obj.CreatedBy;
            }
            else
            {
                obj.CreatedDate = DateTime.Now;
                obj.IsDeleted = false;
                obj.IsActive = true;
                await _dbContext.Departments.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            var rec = await _dbContext.Departments.IgnoreQueryFilters().Where(x => x.IsDeleted != true).OrderBy(x => x.CreatedDate).ToListAsync();
            return rec;
        }
    }
}
