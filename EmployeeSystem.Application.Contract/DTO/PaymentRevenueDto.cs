using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public record PaymentRevenueDto
    {
        public string? PaymentName { get; set; }
        public double Amount { get; set; }

       
    }
}
