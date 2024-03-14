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
using System.Linq.Dynamic.Core;
using Org.BouncyCastle.Ocsp;

namespace EmployeeSystem.Infra.Repositories
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public  class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }

      
    }
    public static class GenericPaginationRepository
    {


        public static async Task< PagedResult<T>> GetPaged<T>(this IQueryable<T> query, string orderColumn,string orderType,
                                      int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            if (!string.IsNullOrEmpty(orderColumn) && ( orderType== "asc" || orderType== "desc"))
                query = query.OrderBy(orderColumn + " " + orderType);

            result.Results =await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }


    }
}
