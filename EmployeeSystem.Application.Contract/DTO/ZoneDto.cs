using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ZoneDto :BaseModel
    {
        public Guid ZoneId { get; set; }
        public Guid BranchId { get; set; }
        public string ZoneName { get; set; } = string.Empty;
        public int totalRecords { get; set; }
    }
  
}
