using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class MarksPolicyDto
    {
        public MarksPolicyDto()
        {
            PolicyDetails = new List<MarksPolicyDetailDto>();
        }
        public Guid? MarksPolicyId { get; set; }
        public Guid AcademicYearId { get; set; }
        public Guid? BranchId { get; set; }
        public string? NameOfAcadmicYear { get; set; }
        public Guid TermId { get; set; }
        public string? TermName { get; set; }
        public Guid? ClassId { get; set; }
        public string? ClassName { get; set; }

        public Guid? CourseId { get; set; }
        public string? CourseName { get; set; }

        public Guid? SectionId { get; set; }
        public string? SectionName { get; set; }

        public double TotalMarks { get; set; }
        public int TotalRecords { get; set; }
        public Nullable<Guid> CreatedBy { get; set; }
        public  List<MarksPolicyDetailDto> PolicyDetails { get; set; }

    }
}
