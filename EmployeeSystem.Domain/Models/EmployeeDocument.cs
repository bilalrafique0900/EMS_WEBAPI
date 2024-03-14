using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public class EmployeeDocument:BaseModel
    {
        [Key]
        public Guid EmployeeDocumentId { get; set; }
        [StringLength(30)]
        public string? DocumentName { get; set; }
        public Guid LovId { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsRequired { get; set; }
    }
}
