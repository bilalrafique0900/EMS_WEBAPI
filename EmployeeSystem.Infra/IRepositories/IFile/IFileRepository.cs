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
        Task<Files> AddFileAsync(Files file);
        Task<IEnumerable<Files>> GetFilesByJobDescriptionIdAsync(Guid jobDescriptionId);
        Task<Files> GetFileByIdAsync(int fileId);
        Task<List<Files>> GetAllFilesAsync();
        Task DeleteFileAsync(int fileId);

        Task<bool> UpdateFileStatusAsync(int fileId, string comment);

    }
}
