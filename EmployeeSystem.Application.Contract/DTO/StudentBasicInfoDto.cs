using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentBasicInfoDto
    {
        public Guid StudentId { get; set; }
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Barcode { get; set; }
        
        public string? FullName { get; set; }
        public string? StudentEmail { get; set; }
        public string? Address { get; set; }
        public Guid? ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public Guid? SectionId { get; set; }
        public string? HCode { get; set; }
        public bool? IsBusServices { get; set; }
        public bool? IsLunchServices { get; set; }
        public bool? IsTaxiServices { get; set; }
        
        public bool? IsBooks { get; set; }
    }
}
