using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class RoleDepartmentDto
    {
        public Guid RoleId { get; set; }

        public Guid DepartmentId { get; set; }
        public string? RoleName { get; set; }

        public string? DepartmentName { get; set; }

        public int? TotalRecords { get; set; }
      
        public bool? IsDeleted { get; set; }
        public Guid? CreatedBy { get; set; }
    
    }
}
