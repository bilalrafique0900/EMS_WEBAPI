using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TimeTableDto :BaseModel
    {
        public Guid TimeTableId { get; set; }
        public Guid TimeTableSlotId { get; set; }
        
        public Guid BranchId { get; set; }
        public Guid RoomId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid ClassId { get; set; }
        public Guid SectionId { get; set; }
        public string SectionName { get; set; }
        public Guid CourseId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? ClassName { get;set; }
        public string? TeacherName { get; set; }
        public string? RoomName { get; set; }
        public string? CourseName { get; set; }
        public bool? IsBreak { get; set; }
    }
}
