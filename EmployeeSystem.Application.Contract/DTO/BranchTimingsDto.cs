using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class BranchTimingsDto :BaseModel
    {
        public Guid BranchTimingsId { get; set; }
        public DateTime? BranchStartsTime { get; set; }
        public DateTime? BranchEndTime { get; set; }
        public DateTime? BreakTime { get; set; }
        public double? TotalRecords { get; set; }
        
    }
}
