using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TermDto : BaseModel
    {
        public Guid? TermId { get; set; }
        public Guid? BranchId { get; set; }
        public string? TermName { get; set; }
        public DateTime? TermStartDate { get; set; }
        public DateTime? TermEndDate { get; set; }
        public string? Description { get; set; }
        public Guid? AcadmicYearId { get; set; }
        public string? AcadmicYear { get; set; }
    }
  
}
