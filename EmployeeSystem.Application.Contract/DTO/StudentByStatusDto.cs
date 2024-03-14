using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentByStatusDto
    {


        public string? FullName { get; set; }
        public string? HCode { get; set; }
        public Guid? ClassId { get; set; }
        public Guid StudentId { get; set; }
        public string? ClassName { get; set; }
        public string? Address { get; set; }
        public string? StudentPhoneNo { get; set; }
        public string? StudentEmail { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PassportNo { get; set; }
        public string? IDNo { get; set; }
        public double? TotalRecords { get; set; }
    }
}