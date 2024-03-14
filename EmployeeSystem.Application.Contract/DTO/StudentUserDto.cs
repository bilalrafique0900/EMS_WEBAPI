namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentUserDto
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? FatherEmail { get; set; }
        public string? FatherName { get; set; }
        public Guid BranchId { get; set; }
        public Guid RoleId { get; set; }
        public Guid StudentId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
