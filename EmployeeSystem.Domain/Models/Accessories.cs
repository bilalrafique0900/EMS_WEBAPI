using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public class Accessories
    {
        public Guid AccessoriesId { get; set; }
        public string AccessoriesName { get; set; }
        public string? AccessBrandName { get; set; }
        public bool? IsActive { get; set; }
    }
}
