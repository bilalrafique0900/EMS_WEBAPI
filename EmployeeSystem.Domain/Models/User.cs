using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;

public partial class User: BaseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UserId { get; set; }

    [Required, StringLength(50)]
    public string Email { get; set; }
    [StringLength(50)]
    public string? FullName { get; set; }

    [Required, StringLength(100)]
    public string Password { get; set; }
    public Guid RoleId { get; set; }
}
