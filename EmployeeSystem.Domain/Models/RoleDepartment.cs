using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;
public partial class RoleDepartment
{
    
    public Guid DepartmentId { get; set; }
    public Guid RoleId { get; set; }
}
