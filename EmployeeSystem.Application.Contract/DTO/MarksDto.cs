using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class MarksDto
    {
        public MarksDto()
        {
            Details = new List<MarksDetailsDto>();
        }

        public Guid? MarksId { get; set; }
        public Guid BranchId { get; set; }
        public Guid TypeId { get; set; }

        public Guid AcademicYearId { get; set; }
        public Guid TermId { get; set; }
        public string? Table { get; set; }
        public Guid? TableRefrenceId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? CourseId { get; set; }
        public Guid? SectionId { get; set; }
        public double TotalMarks { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? LockMarks { get; set; }

        public List<MarksDetailsDto> Details { get; set; }
    }

}