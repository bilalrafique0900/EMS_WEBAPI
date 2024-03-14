using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Application.Contracts.DTO;

public  class SapInvoiceDto
{
    public SapInvoiceDto()
    {
        Items = new List<SapStudentPaymentDto>();

    }

    public string? CardCode { get; set; }
    public string DocumentDate { get; set; }
    public string Reference { get; set; }
    public IEnumerable<SapStudentPaymentDto> Items { get; set; }
    public IEnumerable<SapStudentPaymentInstallmentDto> Installments { get; set; }

}
