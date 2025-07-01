using EmployeeSystem.Domain.Enums;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.IRepositories.IFile;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.Repositories.File
{
    internal class FileRepository : IFileRepository
    {
        private readonly EmployeeDBContext _context;
        public FileRepository(EmployeeDBContext context)  
        {
            _context = context;
        }

        public async Task<CV> AddAsync(CV cv)
        {
            _context.CVs.Add(cv);
            await _context.SaveChangesAsync();
            return cv;
        }

        public async Task<List<CV>> GetAllAsync()
        {
            return await _context.CVs
             .Include(c => c.JobDescription)
             .Include(c => c.PostHost)
             .ToListAsync();
        }
    }
}
