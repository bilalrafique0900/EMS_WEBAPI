using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class PostHost: BaseModel
    {
        [Key]
        public Guid PostHostId { get; set; }

        [Required, StringLength(30)]
        public string PostHostName { get; set; }
    }
}
