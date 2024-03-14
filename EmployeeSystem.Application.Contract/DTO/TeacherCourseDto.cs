using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TeacherCourseDto :BaseModel
    {
        public Guid TeacherCourseId { get; set; }
        public Guid? BranchId { get; set; }
        public string? BranchName { get; set; }
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public Guid TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public double? TotalRecords { get; set; }
    }
}
