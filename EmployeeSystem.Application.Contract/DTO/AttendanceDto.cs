using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class AttendanceDto : BaseModel
    {
        public Guid? AttendanceId { get; set; }
        public Guid? StudentId { get; set; }
        public DateTime Time { get; set; }
        public int Day { get; set; }
        public string? InOut { get; set; }
        public string? StudentFullName { get; set; }
    }
  
}
