using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Infra.IRepositories;
using EmployeeSystem.Infra.IRepositories.ILovType;

namespace EmployeeSystem.Infra.Repositories.MasterData
{
    public class LovTypeRepository : GenericRepository<LOVType>, ILovTypeRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly IRedisCacheService _redisCacheService;
        public IDapperConfig _dapper { get; set; }
        public LovTypeRepository(EmployeeDBContext appDbContext, IDapperConfig dapper, IRedisCacheService redisCacheService) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _redisCacheService = redisCacheService;
        }
        public async Task<IEnumerable<LovSelectItemDto>> GetLovTypeByCode(string lovCode)
        {
            //string redisKey = RedisKey.LovCode.ToString() + lovCode;
            //var cacheData = await _redisCacheService.GetAsync<IEnumerable<LovSelectItemDto>>(redisKey);

            //if (cacheData != null) return cacheData;
            //else
            //{
            //    var query = (from t1 in _dbContext.LOVType
            //                 join t2 in _dbContext.LOVS on t1.LovTypeId equals t2.LovTypeId
            //                 orderby t2.LovName ascending
            //                 select new LovSelectItemDto
            //                 {
            //                     Id = t2.LovId,
            //                     text = t2.LovName,
            //                     code = t2.LovCode,
            //                     loveTypeCode = t1.LovTypeCode
            //                 }).Where(x => x.loveTypeCode == lovCode);
            //    var lovData = await query.ToListAsync();
            //    await _redisCacheService.SetAsync<IEnumerable<LovSelectItemDto>>(redisKey, lovData, TimeSpan.FromMinutes(60));
            //    return lovData;
            //}
            var query = (from t1 in _dbContext.LOVType
                         join t2 in _dbContext.LOVS on t1.LovTypeId equals t2.LovTypeId
                         orderby t2.LovName ascending
                         select new LovSelectItemDto
                         {
                             Id = t2.LovId,
                             text = t2.LovName,
                             code = t2.LovCode,
                             loveTypeCode = t1.LovTypeCode
                         }).Where(x => x.loveTypeCode == lovCode);
            var lovData = await query.ToListAsync();
            return lovData;

        }
        public async Task<LovSelectItemDto> GetLovTypeByName(string Name)
        {

            var query = (from t1 in _dbContext.LOVType
                         join t2 in _dbContext.LOVS on t1.LovTypeId equals t2.LovTypeId
                         orderby t2.LovName ascending
                         select new LovSelectItemDto
                         {
                             Id = t2.LovId,
                             text = t2.LovName,
                             code = t2.LovCode,
                             loveTypeCode = t1.LovTypeCode
                         }).Where(x => x.text == Name);
            var lovData = await query.FirstOrDefaultAsync();
            return lovData;

        }
        public async Task<IEnumerable<StudentAttachmentDto>> GetStuddentLovByLovCode(string lovCode)
        {
            return await _dapper.QueryAsync<StudentAttachmentDto>("GetStudentAttachmentLov", new { @LovTypeCode = lovCode }, CommandType.StoredProcedure).ConfigureAwait(true);
        }
    }
}
