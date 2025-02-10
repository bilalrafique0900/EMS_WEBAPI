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

        public FileRepository(EmployeeDBContext employeeDBContext)
        {
            _context = employeeDBContext;
        }

        public async Task<Files> AddFileAsync(Files file)
        {
            try
            {
                await _context.Files.AddAsync(file);
                await _context.SaveChangesAsync();
                return file;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public async Task<List<Files>> AddFilesAsync(List<Files> files)
        {
            await _context.Files.AddRangeAsync(files);
            await _context.SaveChangesAsync();
            return files;
        }

        public async Task DeleteFileAsync(int fileId)
        {
            var file = await _context.Files.FindAsync(fileId);
            if (file != null)
            {
                _context.Files.Remove(file);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Files> GetFileByIdAsync(int fileId)
        {
            return await _context.Files.FirstOrDefaultAsync(f => f.Id == fileId);
        }

        public async Task<List<Files>> GetAllFilesAsync()
        {
            return await _context.Files.ToListAsync();
        }




        public async Task<IEnumerable<Files>> GetFilesByJobDescriptionIdAsync(Guid jobDescriptionId)
        {
            return await _context.Files.Where(a=>a.JobDescriptionId==jobDescriptionId).ToListAsync();
        }

        public async Task<bool> UpdateFileStatusAsync(int fileId, string status)
        {
            var file = await _context.Files.FindAsync(fileId);
            if (file == null) return false;

            file.Status = status;  
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
