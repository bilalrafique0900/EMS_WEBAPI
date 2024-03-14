namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentMarksDetailsDto
    {
       
        public Guid? MarksDetailId { get; set; }
        public Guid? MarksId { get; set; }
        public Guid StudentId { get; set; }
        public string? TermName { get; set; }
        public string? AcadmicYear { get; set; }
        public string? CourseName { get; set; }
        public double ObtainMarks { get; set; }
        public double TotalMarks { get; set; }
        public string? MarksType { get; set; }
    }
  
}