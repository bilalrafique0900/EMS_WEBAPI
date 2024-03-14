using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class MarksPolicyDetailDto
    {
        public Guid MarksPolicyDetailId { get; set; }
        public Guid MarksPolicyId { get; set; }
        public Guid MarksTypeId { get; set; }
        public Guid PolicyMethodId { get; set; }
        public double? PolicyMethodValue { get; set; }
        public double PolicyMarks { get; set; }

    }
}
