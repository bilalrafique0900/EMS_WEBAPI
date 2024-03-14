using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeSystem.Infra.Repositories.MasterData
{
    public class TemplateRepository : GenericRepository<Template>, ITemplateRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public TemplateRepository(EmployeeDBContext appDbContext, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
        }
        public async Task<bool> CreateUpdate(Template obj)
        {
            var rec = await _dbContext.Templates.FirstOrDefaultAsync(x => x.TemplateId == obj.TemplateId);
            if (rec != null)
            {
                rec.UpdatedDate = DateTime.Now;
                rec.TemplateName = obj.TemplateName;
                rec.TemplateContent = obj.TemplateContent;
                rec.TemplateTypeId = obj.TemplateTypeId;
                rec.BranchId = obj.BranchId;
                rec.UpdatedBy = obj.CreatedBy;
            }
            else
            {
                obj.CreatedDate = DateTime.Now;
                obj.IsDeleted = false;
                obj.IsActive = true;
                await _dbContext.Templates.AddAsync(obj);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.Templates.FirstOrDefaultAsync(x => x.TemplateId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.Templates.FirstOrDefaultAsync(x => x.TemplateId == id);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Template>> GetAllTemplates()
        {
            var rec = await _dbContext.Templates.IgnoreQueryFilters().Where(x => x.IsDeleted != true).OrderBy(x => x.CreatedDate).ToListAsync();
            return rec;
        }

        public async Task<IEnumerable<Template>> GetByKeycods(string[] ForKeyCodes)
        {
            IEnumerable<Template> templates = await (from t in _dbContext.Templates
                                                     join lov in _dbContext.LOVS on t.TemplateTypeId equals lov.LovId
                                                     where ForKeyCodes.Contains(lov.LovCode)
                                                     select new Template
                                                     {
                                                         TemplateKeyCode = lov.LovCode,
                                                         TemplateContent = t.TemplateContent,
                                                         TemplateId = t.TemplateId,
                                                         TemplateName = t.TemplateName,
                                                     }).ToListAsync();
            return templates;
        }
    }
}
