using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class QuestionDto : BaseModel
    {
        public Guid? QuestionId { get; set; }
        public string? Title { get; set; }
        public string? CourseName { get; set; }
        public string? ClassName { get; set; }
        public string? DifficultLeveName { get; set; }
        public Guid? DifficultLevelId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? CourseId { get; set; }
        public string? QuestionDetails { get; set; }
        public Guid? BranchId { get; set; }
        public long? totalRecords { get; set; }
    }
  
}