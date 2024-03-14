using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class EmployeePreviousExperience:BaseModel
    {

        [Key]
        public Guid PreviousExperienceId { get; set; }
        [StringLength(100)]
        public string? YearOfExperience { get; set; }
        
        [StringLength(100)]
        public string? PreviousEmployerAdress { get; set; }
        [StringLength(100)]
        public string? ReasonForLeaving { get; set; }
        [StringLength(100)]
        public string? ReferenceName { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
