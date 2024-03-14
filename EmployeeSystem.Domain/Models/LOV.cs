using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;

public partial class LOV: BaseModel
{
    [Key]
    public Guid LovId { get; set; }

    [Required, StringLength(100)]
    public string? LovName { get; set; }
    [Required, StringLength(100)]
    public string? LovCode { get; set; }
    [ForeignKey("LOVType")]
    public Guid LovTypeId { get; set; }
    public int? SortOrder { get; set; }

}
