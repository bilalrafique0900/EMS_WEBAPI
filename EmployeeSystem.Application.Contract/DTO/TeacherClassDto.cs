using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TeacherClassDto :BaseModel
    {
        public Guid TeacherClassId { get; set; }
        public Guid BranchId { get; set; }
        public string? BranchName { get; set; }
        public Guid ClassId { get; set; }
        public string? ClassName { get; set; }
        public Guid SectionId { get; set; }
        public string? SectionName { get; set; }
        public Guid TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public double? TotalRecords { get; set; }
    }
}
