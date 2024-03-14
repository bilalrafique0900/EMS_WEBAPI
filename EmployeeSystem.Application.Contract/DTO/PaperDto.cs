using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class PaperDto : BaseModel
    {
        public Guid? PaperId { get; set; }
        public string? Title { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? CourseId { get; set; }
        public string? NameOfAcadmicYear { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? TermId { get; set; }
        public Guid? AcademicYearId { get; set; }
        public bool? LockMarks { get; set; }
        public int? TotalMarks { get; set; }
        public long? totalRecords { get; set; }
        public string? CourseName { get; set; }
        public string? ClassName { get; set; }
        public string? TermName { get; set; }

        public DateTime? PaperDate { get; set; }

        public List<PaperDifficultyLevelDto>? PaperDifficultyLevel { get; set; }
    }
  
}
