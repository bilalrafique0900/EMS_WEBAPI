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
    public string? ContactPersonName { get; set; }
    public string? ContactEmailAddress { get; set; }
    [StringLength(100)]
    public string? ContactPhoneNumber { get; set; }
    [StringLength(100)]
    public string? ClientType { get; set; }
    public string? CompanyAddress { get; set; }
    [StringLength(100)]
    public string? NumberOfEmployees { get; set; }
    public string? ServicesRequired { get; set; }
    public DateTime? OnboardingStartDate { get; set; }
    public string? SpecialRequirementOrNotes { get; set; }
    

}
