using EmployeeSystem.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Domain.Models;

public partial class Onboarding: BaseModel
{
    [Key]
    public Guid OnboardingId { get; set; }
    [StringLength(100)]
    public string? CompanyName { get; set; }
    [StringLength(100)]
    public string? ClientId { get; set; }
    public string? ContactPersonInfo { get; set; }
  
    public string? ClientType { get; set; }
    public string? CompanyAddress { get; set; }
    [StringLength(100)]
    public string? NumberOfEmployees { get; set; }
    public string? ServicesRequired { get; set; }
    public DateTime? ContractDate { get; set; }
    public DateTime? OnboardingStartDate { get; set; }
    public string? SpecialRequirementOrNotes { get; set; }
    

}
