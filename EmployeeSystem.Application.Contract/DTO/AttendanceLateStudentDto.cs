using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public record AttendanceLateStudentDto
    {
      
        public string? FullName { get; set; }
        public string? Time { get; set; }
        public string? Firebase { get; set; }

    }
  
}
