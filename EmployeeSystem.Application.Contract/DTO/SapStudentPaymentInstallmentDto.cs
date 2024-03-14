using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Application.Contracts.DTO;

public  class SapStudentPaymentInstallmentDto
{
    public string? DueDate { get; set; }
    public double Percentage { get; set; }
    public double Total { get; set; }
    public string? Reference { get; set; }
    

}
