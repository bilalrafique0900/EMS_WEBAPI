using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class EmployeeFamily: BaseModel
    {

        [Key]
        public Guid FamilyId { get; set; }
        public string? NoOfDependents { get; set; }
        [StringLength(100)]
        public string? NameOfSpouse { get; set; }
        [StringLength(100)]
        public Guid? MaritalStatusId { get; set; }
        [StringLength(100)]
        public Guid? SpouseAliveStatusId { get; set; }
        [StringLength(100)]
        public DateTime? SpouseDateOfBirth { get; set; }
        [StringLength(100)]
        public Guid?EmployeeId { get; set; }
        [StringLength(100)]
        public string? NameOfFather { get; set; }
        [StringLength(100)]
        public Guid? FatherAliveStatusId { get; set; }
        [StringLength(100)]
        public string? FatherContact { get; set; }

        [StringLength(100)]
        public string? NameOfMother { get; set; }
        [StringLength(100)]
        public Guid? MotherAliveStatusId { get; set; }
        [StringLength(100)]
        public string? MotherContact { get; set; }
        [StringLength(100)]
        public string? NoOfSisters { get; set; }
        [StringLength(100)]
        public string? NoOfBrothers { get; set; }
        [StringLength(100)]
        public string? EmergencyContact { get; set; }
        [StringLength(100)]
        public string? EmergencyContactName { get; set; }

    }
}
