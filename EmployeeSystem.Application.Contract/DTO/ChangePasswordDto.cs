using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ChangePasswordDto
    {
        public string? Email { get; set; }
        public Guid? UserId { get; set; }
        public string? Password { get; set; }
        public string? OldPassword { get; set; }
    }
  
}
