using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class PaymentTypeSapConfigDto
    {
        public Guid? PaymentTypeSapConfigId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public string? SapCode { get; set; }
        public string? CostCenter1 { get; set; }
        public string? CostCenter2 { get; set; }
        public string? CostCenter3 { get; set; }
        public string? CostCenter4 { get; set; }
        public string? CostCenter5 { get; set; }
        public string? PayType { get; set; }
        public double? TotalRecords { get; set; }
    }
  
}
