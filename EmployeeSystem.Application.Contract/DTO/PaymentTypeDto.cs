using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Application.Contracts.DTO;

public partial class PaymentTypeDto
{
    public Guid PaymentTypeId { get; set; }
    public string? Type { get; set; }
    public double Amount { get; set; }
    public bool IsRefundable { get; set; }
    public bool AllowInstallment { get; set; }
    public bool AllowDiscount { get; set; }
    public string? SapCode { get; set; }
    public string? Description { get; set; }

}
