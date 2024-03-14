using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentApprovalDto
    {
        public Guid StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhoneNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? ApprovalTypeId { get; set; }
        public string ApprovalName { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApproverName { get; set; }
        public Guid ApprovalId { get; set; }
        public Guid ApprovalConfigId { get; set; }
        public Guid UserId { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public double? TotalRecords { get; set; }
        public string? Comments { get; set; }
    }
}
