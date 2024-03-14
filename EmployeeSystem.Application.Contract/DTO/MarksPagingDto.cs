namespace EmployeeSystem.Application.Contracts.DTO
{
    public class MarksPagingDto
    {
        
        public Guid MarksId { get; set; }
        public Guid BranchId { get; set; }
        public Guid TypeId { get; set; }
        public string? MarksType { get; set; }
        public string? Table { get; set; }
        public Guid? TableRefrenceId { get; set; }
        public Guid? ClassId { get; set; }
        public string? ClassName { get; set; }
        public Guid? CourseId { get; set; }
        public Guid? SectionId { get; set; }
        public string? SectionName { get; set; }
        public string? CourseName { get; set; }
        public double TotalMarks { get; set; }
        public bool? LockMarks { get; set; }
        public Guid? CreatedBy { get; set; }

    }

}