using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.EmployeeAccessoriesRepository
{
    public interface IEmployeeAccessoriesRepository
    {
        Task AddAsync(EmployeeAccessories employeeAccessories);


        Task<EmployeeAccessories> GetByIdAsync(Guid id);
        Task<IEnumerable<EmployeeAccessories>> GetAllAsync();


        Task UpdateAsync(EmployeeAccessories employeeAccessories);
        Task DeleteAsync(Guid id);
    }
}
