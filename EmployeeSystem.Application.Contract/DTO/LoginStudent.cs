namespace EmployeeSystem.Application.Contracts.DTO
{
    public class LoginStudent
    {
        public Guid UserId { get; set; }
        public Guid StudentId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }
        public string? FullName { get; set; }
    }
}
