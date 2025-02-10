using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSystem.Domain.Models;
//using EmployeeSystem.Infra.IRepositories.IFile;
using EmployeeSystem.Infra.IRepositories.IFile;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Authorization;
using StackExchange.Profiling.Internal;

namespace EmployeeSystem.Application.Controllers.JobDescription
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        //1st
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromForm]UploadRequestDto request)
        {
            if (request.Files == null || request.Files.Count == 0)
                return BadRequest("No files uploaded.");

            if (!Guid.TryParse(request.JobDescriptionId, out Guid parsedJobDescriptionId))
                return BadRequest("Invalid JobDescriptionId format.");

            var fileList = new List<Files>();
            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CVs", request.JobDescriptionId);

            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir); 

            foreach (var file in request.Files)
            {
                var filePath = Path.Combine(uploadDir, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var fileModel = new Files
                {
                    FileName = file.FileName,
                    FilePath = filePath,
                    ContentType = file.ContentType,
                    JobDescriptionId = parsedJobDescriptionId
                };

                var savedFile = await _fileRepository.AddFileAsync(fileModel);
                fileList.Add(savedFile);
            }

            return Ok(fileList);
        }



       //2nd
        [HttpPost("test-upload")]
        public IActionResult TestUpload([FromForm] string jobDescriptionId, [FromForm] string jobDescriptionId1)
        {
            Console.WriteLine($"JobDescriptionId: {jobDescriptionId}");
            Console.WriteLine($"JobDescriptionId1: {jobDescriptionId1}");

            if (string.IsNullOrEmpty(jobDescriptionId) || string.IsNullOrEmpty(jobDescriptionId1))
            {
                return BadRequest("JobDescriptionId or JobDescriptionId1 is null or empty.");
            }

            return Ok("Success");
        }



        // 3rd
        [HttpGet("files")]
        public async Task<IActionResult> GetFiles(Guid jobDescriptionId)
        {
            var files = await _fileRepository.GetFilesByJobDescriptionIdAsync(jobDescriptionId);
            if (!files.Any())
                return NotFound("No files found.");

            return Ok(files); 
        }


        [AllowAnonymous] 
        [HttpGet("all-files")]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await _fileRepository.GetAllFilesAsync();
            if (!files.Any())
                return NotFound("No files found.");

            return Ok(files);
        }



        // 5rd
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var file = await _fileRepository.GetFileByIdAsync(id);
            if (file == null)
                return NotFound("File not found.");

            var fileBytes = await System.IO.File.ReadAllBytesAsync(file.FilePath);
            return File(fileBytes, file.ContentType, file.FileName);
        }

        // 6th
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var file = await _fileRepository.GetFileByIdAsync(id);
            if (file == null)
                return NotFound("File not found.");

            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }

            await _fileRepository.DeleteFileAsync(id);
            return Ok("File deleted successfully.");
        }



        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusDto request)
        {
            if (request == null || request.FileId <= 0 || string.IsNullOrWhiteSpace(request.Status))
            {
                return BadRequest(new { message = "Invalid request data." });
            }

            var success = await _fileRepository.UpdateFileStatusAsync(request.FileId, request.Status);

            if (!success)
            {
                return BadRequest(new { message = "Invalid status value or file not found." });
            }

            return Ok(new { message = "Status updated successfully." });
        }


    }

}
