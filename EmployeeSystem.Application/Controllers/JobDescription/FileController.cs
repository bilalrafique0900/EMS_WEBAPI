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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CVDto dto)
        {
            var cv = new CV
            {
                CVCount = dto.CVCount,
                PostHostId = dto.PostHostId,
                JobDescriptionId = dto.JobDescriptionId
            };

            var result = await _fileRepository.AddAsync(cv);
            return Ok(new { message = "CV saved successfully!", data = result.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _fileRepository.GetAllAsync();

            var result = data.Select(c => new CVDto
            {
                Id = c.Id,
                CVCount = c.CVCount,
                PostHostId = c.PostHostId,
                JobDescriptionId = c.JobDescriptionId,
                PostHostName = c.PostHost?.PostHostName,
                JobDescriptionName = c.JobDescription?.Title
            }).ToList();

            return Ok(new { data = result });
        }


    }
}
