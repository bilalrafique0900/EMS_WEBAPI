using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ApprovalHistoryDto
    {
        public Guid StudentId { get; set; }
        public string? FullName { get; set; }
        public string? ApprovalStatus { get; set; }
        public string? Remarks { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? HCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public double? TotalRecords { get; set; }
        public double TotalDiscountPercentage { get; set; }
    }
}
