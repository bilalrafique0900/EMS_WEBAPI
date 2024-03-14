using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class EmployeePreviousExperienceDto : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public Guid PreviousExperienceId { get; set; }
        
        public string? YearOfExperience { get; set; }
        
        public string? PreviousEmployerAdress { get; set; }
        public string? ReasonForLeaving { get; set; }
        public string? ReferenceName { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }



    }
}