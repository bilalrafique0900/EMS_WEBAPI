using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeSystem.Infra.Repositories.MasterData
{
    public class PostHostRepository : GenericRepository<PostHost>, IPostHostRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public PostHostRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }
        public async Task<bool> CreateUpdate(PostHost obj)
        {
            var rec = await _dbContext.PostHosts.FirstOrDefaultAsync(x => x.PostHostId == obj.PostHostId);
            if (rec != null)
            {
                rec.UpdatedDate = DateTime.Now;
                rec.PostHostName = obj.PostHostName;

                rec.UpdatedBy = obj.CreatedBy;
            }
            else
            {
                obj.CreatedDate = DateTime.Now;
                obj.IsDeleted = false;
                obj.IsActive = true;
                await _dbContext.PostHosts.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.PostHosts.FirstOrDefaultAsync(x => x.PostHostId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.PostHosts.FirstOrDefaultAsync(x => x.PostHostId == id);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<PostHost>> GetAllPostHosts()
        {
            var rec = await _dbContext.PostHosts.IgnoreQueryFilters().Where(x => x.IsDeleted != true).OrderBy(x => x.CreatedDate).ToListAsync();
            return rec;
        }

      
    }
}
