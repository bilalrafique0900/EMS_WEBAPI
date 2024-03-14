using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentStatusHistoryDto : BaseModel
    {
        public Guid StudentStatusHistoryId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? statusId { get; set; }
        public string? ReasonForGoing { get; set; }
        [StringLength(100)]
        public string? WhichSchoolGoing { get; set; }
        public DateTime? WithdrawnDate { get; set; }
    }
  
}
