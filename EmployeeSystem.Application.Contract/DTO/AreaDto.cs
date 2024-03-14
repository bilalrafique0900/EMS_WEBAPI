using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class AreaDto : BaseModel
    {
        public Guid AreaId { get; set; }

        [Required, StringLength(200)]
        public string? AreaName { get; set; }
        public string? ZoneName { get; set; }
        public Guid ZoneId { get; set; }
        public Guid BranchId { get; set; }
    }
  
}
