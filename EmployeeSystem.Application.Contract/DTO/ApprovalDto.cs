using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Application.Contracts.DTO;

public partial class ApprovalDto : BaseModel
{
    public Guid ApprovalId { get; set; }
    [Required]
    public Guid ApprovalConfigId { get; set; }

    public Guid BranchId { get; set; }

    [Required]
    public Guid TableReferenceId { get; set; }
    public Guid? ReviewUserId { get; set; }
    [StringLength(50)]
    public string ApprovalStatus { get; set; }
    [StringLength(500)]
    public string Remarks { get; set; } = string.Empty;
    public double? Discount { get; set; }

    public IEnumerable<DiscountDto> Discounts = new List<DiscountDto>();

}
