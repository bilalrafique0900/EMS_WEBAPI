namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TeacherUserDto
    {
        public Guid UserId { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? TeacherEmail { get; set; }
        public string? FirebaseToken { get; set; }
        public Guid BranchId { get; set; }
        public Guid RoleId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
