using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class EmployeeChildren: BaseModel
    {
        [Key]
        public Guid ChildrenId { get; set; }
        [StringLength(100)]
        public Guid? EmployeeId { get; set; }
        [StringLength(100)]
        public string? NameOfChild { get; set; }
        [StringLength(100)]
        public Guid? ChildGenderId { get; set; }
        [StringLength(100)]
        public DateTime? ChildDateOfBirth { get; set; }
    }
}
