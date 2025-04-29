using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class Group: BaseModel
    {
        [Key]
        public Guid GroupId { get; set; }

        [Required, StringLength(30)]
        public string GroupName { get; set; }
        public string? GroupCode { get; set; }
    }
}
