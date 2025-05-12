using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;
public partial class JobPermission
{
    [Key]
    public Guid JobPermssionId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid RoleId { get; set; }
    public bool? IsJobCreator { get; set; }
    public bool? IsJobApprover { get; set; }
    public bool? IsJobPublisher { get; set; }
}
