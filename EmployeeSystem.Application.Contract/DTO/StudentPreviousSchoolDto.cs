using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentPreviousSchoolDto : BaseModel
    {
        public Guid? StudentPreviousSchoolId { get; set; }
        public string? PreviousSchoolName { get; set; }
        public string? PreviousSchoolYear { get; set; }
        public string? PreviousSchoolGrade { get; set; }
        public string? PreviousSchoolCertificate { get; set; }
        public string? PreviousSchoolCertificateNumber { get; set; }
        public DateTime? PreviousSchoolCertificateDate { get; set; }
        public Guid StudentId { get; set; }
        public Guid BranchId { get; set; }
    }
  
}
