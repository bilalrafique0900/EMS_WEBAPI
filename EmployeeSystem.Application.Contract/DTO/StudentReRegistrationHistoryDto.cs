using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentReRegistrationHistoryDto : BaseModel
    {
        public Guid? ReRegisgtrationHistoryId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime? ReNewDate { get; set; }
        public Guid? classId { get; set; }
        public Guid? sectionId { get; set; }
        public Guid? AcadmicYear { get; set; }
    }
  
}
