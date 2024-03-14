using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class CourseAttendanceDto
    {
        public Guid StudentId { get; set; }
        public Guid? ClassId { get; set; }
        public DateTime? Date { get; set; }
        public int? Day { get; set; }
        public string? StudentFullName { get; set; }
        public string? HCode { get; set; }
        public Guid CourseAttendanceId { get; set; }
        public Guid SectionId { get; set; }
        public Guid CourseId { get; set; }
        public string Status { get; set; }

    }
  
}
