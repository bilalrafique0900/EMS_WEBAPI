using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class PaperDifficultyLevelDto : BaseModel
    {
        public Guid? PaperDifficultyLevelId { get; set; }
        public Guid PaperId { get; set; }
        public Guid? DifficultLevelId { get; set; }
        public int? TotalQuestions { get; set; }
        public int? totalRecords { get; set; }
        public string? DifficultLevelname { get; set; }
        public string? PaperTitle { get; set; }
    }
}