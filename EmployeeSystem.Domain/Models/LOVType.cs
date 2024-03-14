using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models;

public partial class LOVType : BaseModel
{
    [Key]
    public Guid LovTypeId { get; set; }

    [Required, StringLength(100)]
    public string? LovTypeName { get; set; }
    [Required, StringLength(100)]
    public string? LovTypeCode { get; set; }

}
