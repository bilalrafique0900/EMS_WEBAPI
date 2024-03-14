using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        Task<ApiResponseModel> GetAll(int page, int pageSize, Expression<Func<T, bool>> where = null);
        Task<List<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<bool> Remove(T entity);
        Task<bool> RemoveRange(IEnumerable<T> entities);
        Task<bool> Any(Expression<Func<T, bool>> predicate);

    }
}
