using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public class Document:BaseModel
    {
        public Guid DocumentId { get; set; }
        public Guid LovId { get; set; }
        [StringLength(20)]
        public string? Table { get; set; }
        public Guid TableRefrenceId { get; set; }
        [StringLength(50)]
        public string? DocumentGuid { get; set; }
        [StringLength(100)]
        public string? DocumentPath { get; set; }
        [StringLength(100)]
        public string? DocumentName { get; set; }
        [StringLength(20)]
        public string? DocumentSize { get; set; }
        [StringLength(5)]
        public string? DocumentExtension { get; set; }
    }
}
