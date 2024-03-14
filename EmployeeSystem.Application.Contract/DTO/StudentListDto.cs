using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentListDto : BaseModel
    {
        public Guid StudentId { get; set; }
        public string? HCode { get; set; }
        //public string? temporaryCode { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? StudentEmail { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ClassName { get; set; }
        public string? SectionName { get; set; }
        public string? LevelName { get; set; }
        public string? GenderName { get; set; }
        public string? SchoolSystem { get; set; }
        public bool? IsSubmitted { get; set; }
        public double? TotalRecords { get; set; }
        public string? StudentStatus { get; set; }
        public string? PaymentAdded { get; set; }
    }
}