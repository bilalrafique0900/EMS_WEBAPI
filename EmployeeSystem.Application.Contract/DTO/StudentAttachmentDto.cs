using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentAttachmentDto
    {
        public Guid LovId { get; set; }
        public string? LovName { get; set; }
        public bool? IsRequired { get; set; }
    }
}
