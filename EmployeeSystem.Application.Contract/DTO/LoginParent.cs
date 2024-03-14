namespace EmployeeSystem.Application.Contracts.DTO
{
    public class LoginParent
    {
        public Guid UserId { get; set; }
        public Guid StudentId { get; set; }
        public Guid ParentId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }
        public string? FullName { get; set; }
    }
}
