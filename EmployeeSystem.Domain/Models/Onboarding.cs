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
    [StringLength(100)]
    public string? ContactEmailAddress { get; set; }
    [StringLength(100)]
    public string? ContactPhoneNumber { get; set; }
    [StringLength(100)]
    public string? ClientType { get; set; }
    [StringLength(100)]
    public string? CompanyAddress { get; set; }
    [StringLength(100)]
    public string? NumberOfEmployees { get; set; }
    [StringLength(100)]
    public string? ServicesRequired { get; set; }
    [StringLength(100)]
    public DateTime? OnboardingStartDate { get; set; }
    [StringLength(100)]
    public string? SpecialRequirementOrNotes { get; set; }
    

}
