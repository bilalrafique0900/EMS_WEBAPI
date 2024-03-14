﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class Department: BaseModel
    {
        [Key]
        public Guid DepartmentId { get; set; }

        [Required, StringLength(30)]
        public string DepartmentName { get; set; }=string.Empty;
    }
}
