using EmployeeSystem.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Domain.Models;

public partial class JobDescription: BaseModel
{
    [Key]
    public Guid JobDescriptionId { get; set; }
    [StringLength(100)]
    public string? Title { get; set; }
    [StringLength(100)]
    public Guid? DepartmentId { get; set; }
    [StringLength(100)]
    public Guid? GroupId { get; set; }
    [StringLength(100)]
    public Guid? HiringManagerId { get; set; }
    [StringLength(100)]
    public Guid? PostHostId { get; set; }
    [StringLength(100)]
    public Guid? EmploymentTypeId { get; set; }
    
    [StringLength(100)]
    public DateTime? JobOpeningDate { get; set; }
    public string? Description { get; set; }
}
