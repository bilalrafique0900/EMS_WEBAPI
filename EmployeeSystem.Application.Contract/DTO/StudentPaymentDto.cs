using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentPaymentRequestDto
    {
        public StudentPaymentRequestDto()
        {
            StudentPaymentTypes = new List<StudentPaymentTypeDto>();
        }
        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }
        public double TotalAmount { get; set; }
        public Guid CreatedBy { get; set; }
        public List<StudentPaymentTypeDto> StudentPaymentTypes { get; set; }
    }
}
