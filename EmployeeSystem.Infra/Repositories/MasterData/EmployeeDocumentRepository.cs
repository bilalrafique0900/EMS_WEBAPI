using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EmployeeSystem.Infra.IRepositories;
using EmployeeSystem.Infra.IRepositories.IMasterData;

namespace EmployeeSystem.Infra.Repositories.MasterData
{
    public class EmployeeDocumentRepository : GenericRepository<EmployeeDocument>, IEmployeeDocumentRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        private readonly IRedisCacheService _redisCacheService;
        public EmployeeDocumentRepository(EmployeeDBContext appDbContext, IRedisCacheService redisCacheService, IDapperConfig dapper) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _redisCacheService = redisCacheService;
        }
        public async Task<bool> CreateUpdate(EmployeeDocument employeeDocument)
        {
            
            var employeeDocumentRecordFormDB = await _dbContext.EmployeeDocuments.FirstOrDefaultAsync(x => x.EmployeeDocumentId == employeeDocument.EmployeeDocumentId);
            if (employeeDocumentRecordFormDB != null)
            {
                employeeDocumentRecordFormDB.DocumentName = employeeDocument.DocumentName;
                employeeDocumentRecordFormDB.IsRequired = employeeDocument.IsRequired;
                employeeDocumentRecordFormDB.UpdatedBy = employeeDocument.CreatedBy;
                employeeDocumentRecordFormDB.UpdatedDate = DateTime.Now;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                await _dbContext.EmployeeDocuments.AddAsync(employeeDocument);
                await _dbContext.SaveChangesAsync();
            }
          //  await _redisCacheService.Remove(RedisKey.EmployeeDocuments.ToString());
            return true;
        }
        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.EmployeeDocuments.FirstOrDefaultAsync(x => x.EmployeeDocumentId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
           // await _redisCacheService.Remove(RedisKey.StudentDocuments.ToString());
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.EmployeeDocuments.FirstOrDefaultAsync(x => x.EmployeeDocumentId == id);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive==true?false:true;
            }
            await _dbContext.SaveChangesAsync();
           // await _redisCacheService.Remove(RedisKey.EmployeeDocuments.ToString());
            return true;
        }
        public async Task<IEnumerable<EmployeeDocument>> GetAllEmployeeDocuments()
        {
            //var cacheData = await _redisCacheService.GetAsync<IEnumerable<EmployeeDocument>>(RedisKey.EmployeeDocuments.ToString());
            //if (cacheData != null) return cacheData;
            //else
            //{
                IEnumerable<EmployeeDocument> employeeDocuments = await _dbContext.EmployeeDocuments.OrderByDescending(x => x.DocumentName).ToListAsync();
                //await _redisCacheService.SetAsync<IEnumerable<EmployeeDocument>>(RedisKey.EmployeeDocuments.ToString(), employeeDocuments, TimeSpan.FromMinutes(60));
                return employeeDocuments;
           // }
        }
        public async Task<bool> IsRequired(Guid id)
        {
            var rec = await _dbContext.EmployeeDocuments.FirstOrDefaultAsync(x => x.EmployeeDocumentId == id);
            if (rec != null)
            {
                rec.IsRequired = rec.IsRequired == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
          //  await _redisCacheService.Remove(RedisKey.EmployeeDocuments.ToString());
            return true;
        }
    }
}
