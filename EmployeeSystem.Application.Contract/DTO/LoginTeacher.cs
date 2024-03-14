namespace EmployeeSystem.Application.Contracts.DTO
{
    public class LoginTeacher
    {
        public Guid UserId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }
        public Guid? CourseId { get; set; }
        public string? FullName { get; set; }
    }
}
