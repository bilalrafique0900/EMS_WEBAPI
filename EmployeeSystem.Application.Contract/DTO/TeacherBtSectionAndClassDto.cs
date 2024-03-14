using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TeacherBtSectionAndClassDto
    {
        public Guid TeacherId { get; set; }
        public Guid SectionId { get; set; }
        public Guid ClassId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? TeacherEmail { get; set; }
        public string? TeacherPhoneNo { get; set; }
        public string? SectionName { get; set; }
        public string? className { get; set; }
    }
}