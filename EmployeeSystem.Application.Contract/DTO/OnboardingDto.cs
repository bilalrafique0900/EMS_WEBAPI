using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class OnboardingDto : BaseModel
    {
        public Guid OnboardingId { get; set; }
        
        public string? CompanyName { get; set; }
        
        public string? ContactPersonName { get; set; }
        
        public string? ContactEmailAddress { get; set; }
        
        public string? ContactPhoneNumber { get; set; }
        
        public string? ClientType { get; set; }
      
        public string? CompanyAddress { get; set; }
        
        public string? NumberOfEmployees { get; set; }
        
        public string? ServicesRequired { get; set; }
        
        public DateTime? OnboardingStartDate { get; set; }
      
        public string? SpecialRequirementOrNotes { get; set; }







    }
}