using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class RoleDto
    {
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
    }
  
}
