using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class EmployeeFamilyDto:BaseModel
    {
        public Guid FamilyId { get; set; }
        public string? NoOfDependents { get; set; }
       
        public string? NameOfSpouse { get; set; }
        
        public Guid? MaritalStatusId { get; set; }
        
        public Guid? SpouseAliveStatusId { get; set; }
        
        public DateTime? SpouseDateOfBirth { get; set; }
      
        public Guid? EmployeeId { get; set; }
      
        public string? NameOfFather { get; set; }
       
        public Guid? FatherAliveStatusId { get; set; }
       
        public string? FatherContact { get; set; }

        
        public string? NameOfMother { get; set; }
       
        public Guid? MotherAliveStatusId { get; set; }
    
        public string? MotherContact { get; set; }
        
        public string? NoOfSisters { get; set; }
        
        public string? NoOfBrothers { get; set; }
       
        public string? EmergencyContact { get; set; }
        
        public string? EmergencyContactName { get; set; }
    }
}
