using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EmployeeSystem.Application.Contracts.DTO;
using iText.Commons.Actions.Contexts;

namespace EmployeeSystem.Infra.Repositories.MasterData
{
    public class LevelRepository : GenericRepository<Level>, ILevelRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public LevelRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }
        public async Task<bool> CreateUpdate(Level obj)
        {
            var rec = await _dbContext.Levels.FirstOrDefaultAsync(x => x.LevelId == obj.LevelId);
            if (rec != null)
            {
                rec.UpdatedDate = DateTime.Now;
                rec.LevelName = obj.LevelName;
                rec.UpdatedBy = obj.CreatedBy;
                rec.Group = obj.Group;
            }
            else
            {
                obj.CreatedDate = DateTime.Now;
                obj.IsDeleted = false;
                obj.IsActive = true;
                await _dbContext.Levels.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.Levels.FirstOrDefaultAsync(x => x.LevelId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.Levels.FirstOrDefaultAsync(x => x.LevelId == id);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<DropdownListDto>> GetAllLevels()
        {
            List<DropdownListDto> list = await (from levels in _dbContext.Levels

                                                                        where levels.IsDeleted != true
                                                                        select new DropdownListDto
                                                                        {
                                                                            Id = levels.LevelId,
                                                                            Name = levels.LevelName,

                                                                        }).ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Level>> GetLevelsByGroupId(Guid GroupId)
        {
            if (GroupId == new Guid("6fb7bfc8-2689-4d04-1f56-08dc4346dcda"))
            {
                var rec = await _dbContext.Levels.IgnoreQueryFilters().Where(x => x.IsDeleted != true && x.Group == "Executive").OrderBy(x => x.CreatedDate).ToListAsync();
                return rec;
            }
            else if (GroupId == new Guid("4d44eeba-3142-418a-b051-bc3f7fb6b965")) {
                var rec = await _dbContext.Levels.IgnoreQueryFilters().Where(x => x.IsDeleted != true && x.Group == "CSuite").OrderBy(x => x.CreatedDate).ToListAsync();
                return rec;
            }
            else
            {
                var rec = await _dbContext.Levels.IgnoreQueryFilters().Where(x => x.IsDeleted != true && x.Group != "Executive" && x.Group != "CSuite").OrderBy(x => x.CreatedDate).ToListAsync();
                return rec;
            }
        }
        public async Task<IEnumerable<Level>> GetLevelsByGroupCode(string GroupCode)
        {
            if (GroupCode!=null && GroupCode!="" && GroupCode!="null")
            {
                var rec = await _dbContext.Levels.IgnoreQueryFilters().Where(x => x.IsDeleted != true && x.Group == GroupCode).OrderBy(x => x.CreatedDate).ToListAsync();
                return rec;
            }
            else
            {
                var rec = await _dbContext.Levels.IgnoreQueryFilters().Where(x => x.IsDeleted != true && x.Group != "Executive" && x.Group != "C-Suite").OrderBy(x => x.CreatedDate).ToListAsync();
                return rec;
            }
        }

    }
}
