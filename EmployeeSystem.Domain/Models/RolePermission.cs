using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;
public partial class RolePermission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid RolePermissionId { get; set; }
    public Guid PermissionItemId { get; set; }
    public Guid RoleId { get; set; }
}
