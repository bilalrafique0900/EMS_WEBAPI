using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Application.Contracts.DTO;

public  class SapStudentPaymentDto
{
   public SapStudentPaymentDto()
    {
        Quantity= 1;
    }
    public string? ItemCode { get; set; }
    public string? StudentPaymentId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double DiscountPercent { get; set; }
    public string? CostCenter { get; set; }
    public string? CostCenter2 { get; set; }
    public string? CostCenter3 { get; set; }
    public string? CostCenter4 { get; set; }
    public string? CostCenter5 { get; set; }
    public string? FreeText { get; set; }
    public string? PaymentCreatedDate { get; set; }

}
