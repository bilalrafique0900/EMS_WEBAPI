using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ClassSectionDto : BaseModel
    {
        public Guid ClassSectionId { get; set; }
        public Guid BranchId { get; set; }
        public string? BranchName { get; set; }
        public Guid ClassId { get; set; }
        public string? ClassName { get; set; }
        public Guid SectionId { get; set; }
        public string? SectionName { get; set; }
        public string? Description { get; set; }
        public double? TotalRecords { get; set; }
    }
}
