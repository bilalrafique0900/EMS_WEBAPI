using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class EmployeeEducationDto : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public Guid EducationId { get; set; }
        public Guid? EducationTypeId { get; set; }
        public string? NameOfHighestDegree { get; set; }
        public string? NameOfInstitute { get; set; }
        public string? PassingYear { get; set; }
      
       
       

    }
}