using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public class Template:BaseModel
    {
        [Key]
        public Guid TemplateId { get; set; }
        [Required, StringLength(80)]
        public string TemplateName { get; set; }
        public Guid TemplateTypeId { get; set; }
        [StringLength(50)]
        public string? TemplateKeyCode { get; set; }
        public string TemplateContent { get; set; }
        public Guid BranchId { get; set; }
    }
}
