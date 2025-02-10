using EmployeeSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class UpdateStatusDto
    {
        public int FileId { get; set; }
        public string Status { get; set; }
    }
}
