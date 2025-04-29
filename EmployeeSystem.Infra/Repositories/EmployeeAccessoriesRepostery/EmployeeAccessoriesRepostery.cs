using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.IRepositories.EmployeeAccessoriesRepository;

namespace EmployeeSystem.Infra.Repositories.EmployeeAccessoriesRepostery
{
    internal class EmployeeAccessoriesRepostery : IEmployeeAccessoriesRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeAccessoriesRepostery(EmployeeDBContext employeeDBContext)
        {
            _dbContext = employeeDBContext;
        }

        public async Task AddAsync(EmployeeAccessories employeeAccessories)
        {
            await _dbContext.EmployeeAccessories.AddAsync(employeeAccessories);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbContext.EmployeeAccessories.FindAsync(id);
            if (entity != null)
            {
                _dbContext.EmployeeAccessories.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmployeeAccessories>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.EmployeeAccessories.ToList());
        }

        public async Task<EmployeeAccessories> GetByIdAsync(Guid id)
        {
            return await _dbContext.EmployeeAccessories.FindAsync(id);
        }

        public async Task UpdateAsync(EmployeeAccessories employeeAccessories)
        {
            _dbContext.EmployeeAccessories.Update(employeeAccessories);
            await _dbContext.SaveChangesAsync();
        }
    }
}
