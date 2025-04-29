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
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public GroupRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }
        public async Task<bool> CreateUpdate(Group obj)
        {
            var rec = await _dbContext.Groups.FirstOrDefaultAsync(x => x.GroupId == obj.GroupId);
            if (rec != null)
            {
                rec.UpdatedDate = DateTime.Now;
                rec.GroupName = obj.GroupName;
                rec.UpdatedBy = obj.CreatedBy;
            }
            else
            {
                obj.CreatedDate = DateTime.Now;
                obj.IsDeleted = false;
                obj.IsActive = true;
                await _dbContext.Groups.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.Groups.FirstOrDefaultAsync(x => x.GroupId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.Groups.FirstOrDefaultAsync(x => x.GroupId == id);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<DropdownListDto>> GetAllGroups()
        {
            List<DropdownListDto> list = await (from groups in _dbContext.Groups

                                                                        where groups.IsDeleted != true
                                                                        select new DropdownListDto
                                                                        {
                                                                            Id = groups.GroupId,
                                                                            Name = groups.GroupName,
Code=groups.GroupCode
                                                                        }).ToListAsync();
            return list;
        }

    }
}
