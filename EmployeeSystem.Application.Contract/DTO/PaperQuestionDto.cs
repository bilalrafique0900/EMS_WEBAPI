using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class PaperQuestionDto : BaseModel
    {
        public Guid? PaperQuestionId { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? PaperId { get; set; }
        public string? PaperTitle { get; set; }
        public string? QuestionTitle { get; set; }
        public long? totalRecords { get; set; }
    }
  
}
