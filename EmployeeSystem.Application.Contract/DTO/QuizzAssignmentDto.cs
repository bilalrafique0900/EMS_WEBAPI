using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class QuizzAssignmentDto : BaseModel
    {
        public Guid? QuizzAssignmentId { get; set; }
        public Guid BranchId { get; set; }
        public Guid ClassId { get; set; }
        public Guid ClassCourseId { get; set; }
        public Guid AcadmicYearId { get; set; }
        public Guid SectionId { get; set; }
        public Guid TypeId { get; set; }
        public Guid TermId { get; set; }
        public string? QuizzAssignmentName { get; set; }
        public string? Description { get; set; }
        public string? BranchName { get; set; }
        public string? ClassName { get; set; }
        public string? CourseName { get; set; }
        public string? TypeName { get; set; }
        public string? TypeNameKeyCode { get; set; }
        public string? TermName { get; set; }
        public string? SectionName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long TotalMarks { get; set; }
        public long ObtainMarks { get; set; }
        public bool IsLock { get; set; }
    }
}