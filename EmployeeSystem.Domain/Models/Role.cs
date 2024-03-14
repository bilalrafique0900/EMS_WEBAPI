using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;

public partial class Role: BaseModel
{
    public Role() => IsSystem = false;
    [Key]
    public Guid RoleId { get; set; }

    [Required, StringLength(30)]
    public string RoleName { get; set; }
    [StringLength(30)]
    public string? DefaultUrl { get; set; }

    [Required, StringLength(30)]
    public string KeyCode { get; set; }

    public bool IsSystem { get; set; }

}
