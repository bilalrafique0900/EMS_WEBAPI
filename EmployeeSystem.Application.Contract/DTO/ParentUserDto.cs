using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ParentUserDto
    {
        public Guid UserId { get; set; }
        public Guid ParentId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? StudentClassId { get; set; }
        public Guid? StudentSectionId { get; set; }
        
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? StudentFullName { get; set; }
        public string? FirebaseToken { get; set; }
        
    }
}
