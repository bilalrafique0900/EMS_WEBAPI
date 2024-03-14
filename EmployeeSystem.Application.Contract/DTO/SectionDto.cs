using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class SectionDto
    {
        public Guid SectionId { get; set; }

        public Guid? BranchId { get; set; }

        public string? SectionName { get; set; }

        public string? Description { get; set; }
    }
}
