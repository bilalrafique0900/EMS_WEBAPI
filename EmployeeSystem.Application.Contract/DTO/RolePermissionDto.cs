using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class RolePermissionDto
    {
        public dynamic? json { get; set; }
        public Guid RoleId { get; set; }
    }
}
