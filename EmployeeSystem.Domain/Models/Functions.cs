using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class Functions: BaseModel
    {
        [Key]
        public Guid FunctionId { get; set; }
        [Required]
        public Guid GroupId { get; set; }

        [Required, StringLength(30)]
        public string FunctionName { get; set; }=string.Empty;  
    }
}
