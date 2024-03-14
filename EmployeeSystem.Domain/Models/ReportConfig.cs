using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;

public partial class ReportConfig : BaseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ReportConfigId { get; set; }
    public Guid? BranchId { get; set; }

    [StringLength(100)]
    public string? Title { get; set; }

    [StringLength(300)]
    public string? Query { get; set; }
}
