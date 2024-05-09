using EmployeeSystem.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Domain.Models;

public partial class Employee: BaseModel
{
    [Key]
    public Guid EmployeeId { get; set; }
    [StringLength(100)]
    public Guid? JobDescriptionId { get; set; }

    [StringLength(100)]
    public string? EmployeeCode { get; set; }
    [StringLength(100)]
    public Guid? EmployeeDesignationId { get; set; }
    [StringLength(100)]
    public Guid? EmploymentTypeId { get; set; }
    [StringLength(100)]
    public Guid? GroupId { get; set; }
    [StringLength(100)]
    public Guid? LevelId { get; set; }
    [StringLength(100)]
    public Guid? DepartmentId { get; set; }
    [StringLength(100)]
    public Guid? FunctionId { get; set; }
    [StringLength(100)]
    public string? FirstName { get; set; }
    [StringLength(100)]
    public string? MiddleName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [StringLength(100)]
    public string? PersonalEmail { get; set; }
    [StringLength(100)]
    public string? Contact { get; set; }
    [StringLength(100)]
    public DateTime? DateOfJoining { get; set; }
    [StringLength(100)]
    public DateTime? DateOfBirth { get; set; }
  
    [StringLength(100)]
    public Guid? GenderId { get; set; }
    [StringLength(100)]
    public Guid? EmployeeTypeId { get; set; }
    [StringLength(100)]
    public Guid? MaritalStatusId { get; set; }
    [StringLength(100)]
    public Guid? EducationTypeId { get; set; }
    [StringLength(100)]
    public string? Cnic { get; set; }

    public bool? IsPicturePermission { get; set; }
    [StringLength(100)]
    public string? Picture { get; set; }
    [StringLength(500)]
    public string? StreetAddress { get; set; }
    [StringLength(200)]
    public string? Mohallah { get; set; }
    [StringLength(100)]
    public string? City { get; set; }
    [StringLength(50)]
    public string? State { get; set; }
    public string? PermanentStreetAddress { get; set; }
    [StringLength(200)]
    public string? PermanentMohallah { get; set; }
    [StringLength(100)]
    public string? PermanentCity { get; set; }
    [StringLength(50)]
    public string? PermanentTehsil { get; set; }
    [StringLength(50)]
    public string? PermanentDistrict { get; set; }
    [StringLength(50)]
    public string? PermanentState { get; set; }
    [StringLength(100)]
    public string? ApprovalStatus { get; set; }
    public bool? IsSubmitted { get; set; }
    [StringLength(100)]
    public string? Status { get; set; }
}
