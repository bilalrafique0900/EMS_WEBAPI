using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;

public partial class ReportConfigDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ReportConfigDetailId { get; set; }
    public Guid ReportConfigId { get; set; }

    [StringLength(10)]
    public string? ParameterType { get; set; }

    [StringLength(100)]
    public string? ParameterName { get; set; }

    [StringLength(100)]
    public string? ParameterDefaultValue { get; set; }

    
}
