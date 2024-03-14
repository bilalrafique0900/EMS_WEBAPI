using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TeacherDto : BaseModel
    {
        public Guid TeacherId { get; set; }
        public Guid BranchId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? TeacherEmail { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public Guid? GenderId { get; set; }
        public string? Area { get; set; }
        public string? Zone { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public double? TotalRecords { get; set; }

    }
}