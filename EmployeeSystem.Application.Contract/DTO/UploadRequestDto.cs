using EmployeeSystem.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class UploadRequestDto
    {
        public List<IFormFile> Files { get; set; }
        public string JobDescriptionId { get; set; }

    }
}
