using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TeacherDetailDto : BaseModel
    {
        public Guid TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string? TeacherEmail { get; set; }
        public string? TeacherPhoneNo { get; set; }
        public double? TotalRecords { get; set; }
    }
}