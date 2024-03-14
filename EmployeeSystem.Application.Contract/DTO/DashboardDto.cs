using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class DashboardDto
    {
        public DashboardDto()
        {
            TodayBirthDays = new List<BirthDaysDto>();
            RecentInvoices = new List<RecentInvoicesDto>();
            ZoneCount = new List<ZoneCountDto>();
            PaymentSales = new List<PaymentSaleDto>();
        }
        public int NewStudents { get; set; }
        public int ReRegister { get; set; }
        public int PendingReregister { get; set; }
       public List<BirthDaysDto> TodayBirthDays { get; set; }
       public List<RecentInvoicesDto> RecentInvoices { get; set; }
       public List<ZoneCountDto> ZoneCount { get; set; }
       public List<PaymentSaleDto> PaymentSales { get; set; }
    }

    public class BirthDaysDto
    {
        public string? FullName { get; set; }
        public string? HCode { get; set; }
    }

    public class RecentInvoicesDto
    {
        public string? FullName { get; set; }
        public string? HCode { get; set; }
        public double TotalAmount { get; set; }
        public string? ClassName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class ZoneCountDto
    {
        public string? ZoneName { get; set; }
        public int Count { get; set; }
    }

    public class PaymentSaleDto
    {
        public string? PaymentGroup { get; set; }
        public int StudentCount { get; set; }
        public double GrossAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double NetAmount { get; set; }
    }
}
