using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class EmployeeEducation : BaseModel

    {
        [Key]
        public Guid EducationId { get; set; }
        [StringLength(100)]
        public string? NameOfHighestDegree { get; set; }
        [StringLength(100)]
        public string? NameOfInstitute { get; set; }
        [StringLength(100)]
        public string? PassingYear { get; set; }
       
        public Guid EmployeeId { get; set; }
    }   
}
