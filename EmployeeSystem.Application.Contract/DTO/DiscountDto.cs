using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class DiscountDto : BaseModel
    {
        public Guid DiscountId { get; set; }
        public Guid BranchId { get; set; }
        public string? BranchName { get; set; }
        public Guid DiscountTypeId { get; set; }
        public string DiscountTypeName{ get; set; }

        [Required, StringLength(30)]
        public string? DiscountName { get; set; }

        [Required, StringLength(100)]
        public string? Description { get; set; }
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public int? SiblingCount { get; set; }
        public bool AllowMultiple { get; set; }
        public double? TotalRecords { get; set; }
    }
}
