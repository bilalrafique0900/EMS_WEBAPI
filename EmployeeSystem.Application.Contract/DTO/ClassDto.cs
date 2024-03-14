using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ClassDto
    {
        public Guid ClassId { get; set; }

        public string? ClassName { get; set; }

        public string? Description { get; set; }
    }
}
