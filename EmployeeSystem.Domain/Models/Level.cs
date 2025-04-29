using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class Level: BaseModel
    {
        [Key]
        public Guid LevelId { get; set; }

        [Required, StringLength(30)]
        public string LevelName { get; set; }
        public string? Group{ get; set; }
    }
}
