using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ContractDto
    {
        public Guid StudentId { get; set; }
        public string? Session { get; set; }
        public string? FullName { get; set; }        
        public string? FatherName { get; set; }
        public string? HCode { get; set; }
        public string? ClassName { get; set; }
        public string? ApplicationFee { get; set; }
        public string? TuitionFee { get; set; }
        public string? BusFee { get; set; }
        public string? LunchFee { get; set; }
        public string? TaxiFee { get; set; }
        public string? ResourceFee { get; set; }
        public string? TotalFee { get; set; }

    }
}