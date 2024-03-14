using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ApprovalConfigurationDto : BaseModel
    {
        public Guid? ApprovalConfigId { get; set; }
        public Guid ApprovalTypeId { get; set; }
        public string? ApprovalName { get; set; }
        public int Steps { get; set; }
        public Guid UserId { get; set; }
        public Guid[]? users { get; set; }
        public string? ReviewUser { get; set; }
        public double? TotalRecords { get; set; }
    }
}
