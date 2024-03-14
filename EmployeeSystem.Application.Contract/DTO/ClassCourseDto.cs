using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ClassCourseDto : BaseModel
    {
        public Guid ClassCourseId { get; set; }
        public Guid ClassId { get; set; }
        public string? ClassName { get; set; }
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public double? TotalRecords { get; set; }
    }
}
