using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IIAceessriesRepo
{
    public interface IAceessriesRepository
    {
        Task<bool> Create(Accessories accessories);
        Task<bool> Update(Accessories accessories);
        Task<bool> Active(Guid id);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Accessories>> GetAllAccessories();

        Task<bool> UpdateMultiple(List<Accessories> accessoriesList);
    }
}
