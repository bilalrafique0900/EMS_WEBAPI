using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class EmployeeListDto : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalEmail { get; set; }
        public string? Cnic { get; set; }
        public string? Contact { get; set; }
        public bool? IsSubmitted { get; set; }
        public double? TotalRecords { get; set; }
    }
}