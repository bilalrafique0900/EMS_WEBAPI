using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class BranchDto : BaseModel
    {
        public Guid BranchId { get; set; }

        public Guid InstituteId { get; set; }
        public string? InstituteName { get; set; }
        public string? BranchName { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public double? TotalRecords { get; set; }
    }
}
