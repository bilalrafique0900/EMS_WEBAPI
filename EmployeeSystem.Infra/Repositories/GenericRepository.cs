using Microsoft.EntityFrameworkCore;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Infra.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmployeeSystem.Domain.Common.CommonMethod;
using System.Runtime.CompilerServices;

namespace EmployeeSystem.Infra.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> _entity;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<T> Get(int id)
        {
            return await _entity.FindAsync(id);
        }
        public IQueryable<T> GetAll()
        {
            return _entity.AsQueryable();
        }
        public virtual async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _entity.Where(predicate).ToListAsync();
        }
        public virtual async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _entity.AnyAsync(predicate);
        }
        public virtual async Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _entity.SingleOrDefaultAsync(predicate);
        }
        public virtual async Task<T> Add(T entity)
        {
            await _entity.AddAsync(entity);
            _ = await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            await _entity.AddRangeAsync(entities);
            _ = await _context.SaveChangesAsync();
            return entities;
        }
        public virtual async Task<T> Update(T entity)
        {
            _entity.Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            _ = await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<bool> Remove(T entity)
        {
            _entity.Remove(entity);
            _ = await _context.SaveChangesAsync();
            return true;
        }
        public virtual async Task<bool> RemoveRange(IEnumerable<T> entities)
        {
            _entity.RemoveRange(entities);
            _ = await _context.SaveChangesAsync();
            return true;
        }
        public async Task<ApiResponseModel> GetAllBySkip(int skip, int pageSize, Expression<Func<T, bool>> where = null)
        {
            List<T> list;
            try
            {
                long Count = 0;
                IQueryable<T> dbQuery = _context.Set<T>();
                if (where == null)
                {
                    Count = dbQuery.AsNoTracking().Count();
                    list = await dbQuery.IgnoreQueryFilters().AsNoTracking().Skip(skip).Take(pageSize).ToListAsync();
                }
                else
                {
                    Count = dbQuery.AsNoTracking().Where(where).Count();
                    list = await dbQuery.IgnoreQueryFilters().AsNoTracking().Where(where).Skip(skip).Take(pageSize).ToListAsync();
                }
                return new ApiResponseModel
                {
                    Status = true,
                    Message = list.Count == 0 ? StaticVariables.RecordNotFound : StaticVariables.RecordFounded,
                    Data = list,
                    totalCount = Count
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"could not be saved: {ex.Message}");
            }
        }
        public async Task<long> GetCount(Expression<Func<T, bool>> where = null)
        {
            long Count = 0;
            IQueryable<T> dbQuery = _context.Set<T>();
            if (where == null)
                Count = await dbQuery.CountAsync<T>();
            else
                Count = await dbQuery.Where(where).CountAsync<T>();
            return Count;
        }
        public async Task<ApiResponseModel> GetAll(int page, int pageSize, Expression<Func<T, bool>> where = null)
        {
            try
            {
                int skip = 0;
                skip = (page - 1) * pageSize;
                return await GetAllBySkip(skip, pageSize, where);
            }
            catch (Exception ex)
            {
                throw new Exception($"could not be saved: {ex.Message}");
            }
        }
    }
}
