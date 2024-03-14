using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentsForUserDto
    {


        public string? FullName { get; set; }
        public string? HCode { get; set; }
        public Guid StudentId { get; set; }
        public string? StudentEmail { get; set; }
        
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? StudentPhoneNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalRecords { get; set; }
        
    }
}