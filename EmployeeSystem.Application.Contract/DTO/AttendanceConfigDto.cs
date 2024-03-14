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
    public class AttendanceConfigDto
    {
        public AttendanceConfigDto()
        {
            CreatedDate = DateTime.Now;
        }
        public Guid? AttendanceConfigId { get; set; }
        public Guid BranchId { get; set; }

        public TimeSpan StudentLateTime { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

    }
  
}
