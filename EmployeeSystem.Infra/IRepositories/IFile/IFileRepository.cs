using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.IRepositories.IFile
{
    public interface IFileRepository
    {
        Task<List<CV>> GetAllAsync();
        Task<CV> AddAsync(CV cv);

    }
}
