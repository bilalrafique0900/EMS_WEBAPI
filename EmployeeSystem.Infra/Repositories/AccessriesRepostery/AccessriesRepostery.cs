using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.IRepositories.IIAceessriesRepo;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSystem.Infra.Repositories.AccessriesRepostery
{
    public class AccessriesRepostery : IAceessriesRepository
    {
        private readonly EmployeeDBContext _dbContext;

        public AccessriesRepostery(EmployeeDBContext employeeDBContext)
        {
            _dbContext = employeeDBContext;
        }

        public async Task<bool> Active(Guid id)
        {
            var accessory = await _dbContext.Accessories.FindAsync(id);
            if (accessory == null) return false;
            // Assuming you have an 'IsActive' property
            accessory.IsActive = true;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Create(Accessories accessories)
        {
            try
            {
                await _dbContext.Accessories.AddAsync(accessories);
                int result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DB Error: {ex.InnerException?.Message ?? ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var accessory = await _dbContext.Accessories.FindAsync(id);
            if (accessory == null) return false;

            _dbContext.Accessories.Remove(accessory);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Accessories>> GetAllAccessories()
        {
            return await _dbContext.Accessories.ToListAsync();
        }

        public async Task<bool> Update(Accessories accessories)
        {
            if (accessories == null) return false;

            var existingAccessory = await _dbContext.Accessories.FindAsync(accessories.AccessoriesId);
            if (existingAccessory == null) return false;

            existingAccessory.AccessoriesName = accessories.AccessoriesName;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateMultiple(List<Accessories> accessoriesList)
        {
            foreach (var accessory in accessoriesList)
            {
                var existingAccessory = await _dbContext.Accessories.FindAsync(accessory.AccessoriesId);
                if (existingAccessory != null)
                {
                    existingAccessory.AccessBrandName = accessory.AccessBrandName;
                    existingAccessory.IsActive = accessory.IsActive;
                    existingAccessory.AccessBrandName = "Test";
                }
            }
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
