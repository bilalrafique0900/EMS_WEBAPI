using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentPaymentTypeDto
    {
        public Guid StudentPaymentTypeId { get; set; }
        public Guid StudentPaymentId { get; set; }
        public Guid StudentId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double TotalAmount { get; set; }
        public string? PaymentTypeName { get; set; }

        public string? SapCode { get; set; }
    }
}
